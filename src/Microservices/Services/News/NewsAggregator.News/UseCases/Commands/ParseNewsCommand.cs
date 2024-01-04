using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Databases.EntityFramework.News.Repositories;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Services.Parsers;

namespace NewsAggregator.News.UseCases.Commands
{
    public class ParseNewsCommand : IRequest<NewsDto>
    {
        public string NewsUrl { get; }

        public ParseNewsCommand(string newsUrl)
        {
            NewsUrl = newsUrl;
        }

        public class Validator : AbstractValidator<ParseNewsCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsUrl).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<ParseNewsCommand, NewsDto>
        {
            private readonly INewsParser _parser;
            private readonly INewsSourceRepository _repository;

            public Handler(INewsParser parser, INewsSourceRepository repository)
            {
                _parser = parser;
                _repository = repository;
            }

            public async Task<NewsDto> Handle(ParseNewsCommand request, CancellationToken cancellationToken)
            {
                var newsUri = new Uri(request.NewsUrl);

                var newsSource = await _repository.FindNewsSourceBySiteUrlAsync($"{newsUri.Scheme}://{newsUri.Host}/",
                    cancellationToken);

                if (newsSource is not null && newsSource.ParseSettings is not null)
                {
                    return await _parser.ParseAsync(
                        request.NewsUrl, 
                        new NewsParserOptions(
                            newsSource.ParseSettings.TitleXPath, 
                            newsSource.ParseSettings.ParseSubTitleSettings?.TitleXPath,
                            newsSource.ParseSettings.ParseEditorSettings?.NameXPath,
                            newsSource.ParseSettings.ParsePictureSettings?.UrlXPath,
                            newsSource.ParseSettings.DescriptionXPath,
                            newsSource.ParseSettings.ParsePublishedAtSettings?.PublishedAtXPath,
                            newsSource.ParseSettings.ParsePublishedAtSettings?.PublishedAtFormat,
                            newsSource.ParseSettings.ParsePublishedAtSettings?.PublishedAtCultureInfo),
                        cancellationToken);
                }
                else throw new NewsSourceNotFoundException(newsUri.Host);
            }
        }

        internal class ParsedNewsNotificationHandler : INotificationHandler<ParsedNews>
        {
            private readonly IMessageBus _messageBus;

            public ParsedNewsNotificationHandler(IMessageBus messageBus)
            {
                _messageBus = messageBus;
            }

            public async Task Handle(ParsedNews notification, CancellationToken cancellationToken)
            {
                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
