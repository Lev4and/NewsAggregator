using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;

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
            private readonly INewsUrlsParser _parser;
            private readonly INewsSourceRepository _repository;
            private readonly INewsListHtmlPageProvider _newsListHtmlPageProvider;

            public Handler(INewsUrlsParser parser, INewsSourceRepository repository, 
                INewsListHtmlPageProvider newsListHtmlPageProvider)
            {
                _parser = parser;
                _repository = repository;
                _newsListHtmlPageProvider = newsListHtmlPageProvider;
            }

            public async Task<IReadOnlyCollection<string>> Handle(SearchNewsCommand request, 
                CancellationToken cancellationToken)
            {
                var newsSource = await _repository.FindNewsSourceBySiteUrlAsync(request.SiteUrl, cancellationToken);

                if (newsSource != null && newsSource.SearchSettings != null)
                {
                    var html = await _newsListHtmlPageProvider.ProvideAsync(request.SiteUrl, cancellationToken);

                    return await _parser.ParseAsync(newsSource.SearchSettings.NewsSiteUrl, html,
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
