using FluentValidation;
using MediatR;
using NewsAggregator.News.Exceptions;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;

namespace NewsAggregator.News.UseCases.Commands
{
    public class SearchNewsBySiteUrlCommand : IRequest<IReadOnlyCollection<string>>
    {
        public string SiteUrl { get; }

        public SearchNewsBySiteUrlCommand(string siteUrl)
        {
            SiteUrl = siteUrl;
        }

        public class Validator : AbstractValidator<SearchNewsBySiteUrlCommand>
        {
            public Validator()
            {
                RuleFor(command => command.SiteUrl).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<SearchNewsBySiteUrlCommand, IReadOnlyCollection<string>>
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

            public async Task<IReadOnlyCollection<string>> Handle(SearchNewsBySiteUrlCommand request, 
                CancellationToken cancellationToken)
            {
                var newsSource = await _repository.FindNewsSourceBySiteUrlAsync(request.SiteUrl, 
                    cancellationToken);

                if (newsSource is not null && newsSource.SearchSettings is not null)
                {
                    var html = await _newsListHtmlPageProvider.ProvideAsync(request.SiteUrl, 
                        cancellationToken);

                    return await _parser.ParseAsync(newsSource.SearchSettings.NewsSiteUrl, html,
                        new NewsUrlsParserOptions(newsSource.SearchSettings.NewsUrlXPath), cancellationToken);
                }
                else
                {
                    throw new NewsSourceNotFoundException(new Uri(request.SiteUrl).Host);
                }
            }
        }
    }
}
