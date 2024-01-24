using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;

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
            private readonly INewsHtmlPageProvider _newsHtmlPageProvider;

            public Handler(INewsParser parser, INewsSourceRepository repository, INewsHtmlPageProvider newsHtmlPageProvider)
            {
                _parser = parser;
                _repository = repository;
                _newsHtmlPageProvider = newsHtmlPageProvider;
            }

            public async Task<NewsDto> Handle(ParseNewsCommand request, CancellationToken cancellationToken)
            {
                var newsUri = new Uri(request.NewsUrl);

                var newsSource = await _repository.FindNewsSourceBySiteUrlAsync($"{newsUri.Scheme}://{newsUri.Host}/",
                    cancellationToken);

                if (newsSource is not null && newsSource.ParseSettings is not null)
                {
                    var html = await _newsHtmlPageProvider.ProvideAsync(request.NewsUrl, cancellationToken);

                    return await _parser.ParseAsync(request.NewsUrl, html, 
                        newsSource.ParseSettings.ToNewsParserOptions(), cancellationToken);
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

        internal class NotParsedNewsNotificationHandler : INotificationHandler<NotParsedNews>
        {
            private readonly IMessageBus _messageBus;

            public NotParsedNewsNotificationHandler(IMessageBus messageBus)
            {
                _messageBus = messageBus;
            }

            public async Task Handle(NotParsedNews notification, CancellationToken cancellationToken)
            {
                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
