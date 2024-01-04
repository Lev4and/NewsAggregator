using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Databases.EntityFramework.News.Repositories;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Services.Parsers;

namespace NewsAggregator.News.UseCases.Commands
{
    public class SearchNewsCommand : IRequest<IReadOnlyCollection<string>>
    {
        public string SiteUrl { get; }

        public SearchNewsCommand(string siteUrl)
        {
            SiteUrl = siteUrl;
        }

        public class Validator : AbstractValidator<SearchNewsCommand>
        {
            public Validator()
            {
                RuleFor(command => command.SiteUrl).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<SearchNewsCommand, IReadOnlyCollection<string>>
        {
            private readonly INewsSourceRepository _repository;
            private readonly INewsUrlsParser _parser;

            public Handler(INewsSourceRepository repository, INewsUrlsParser parser)
            {
                _repository = repository;
                _parser = parser;
            }

            public async Task<IReadOnlyCollection<string>> Handle(SearchNewsCommand request, 
                CancellationToken cancellationToken)
            {
                var newsSource = await _repository.FindNewsSourceBySiteUrlAsync(request.SiteUrl, cancellationToken);

                if (newsSource != null && newsSource.SearchSettings != null)
                {
                    return await _parser.ParseAsync(newsSource.SearchSettings.NewsSiteUrl, 
                        new NewsUrlsParserOptions(newsSource.SearchSettings.NewsUrlXPath), cancellationToken);
                }
                else throw new NewsSourceNotFoundException(new Uri(request.SiteUrl).Host);
            }
        }

        internal class FoundNewsHotificationHandler : INotificationHandler<FoundNews>
        {
            private readonly IMessageBus _messageBus;

            public FoundNewsHotificationHandler(IMessageBus messageBus)
            {
                _messageBus = messageBus;
            }

            public async Task Handle(FoundNews notification, CancellationToken cancellationToken)
            {
                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
