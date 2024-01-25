using FluentValidation;
using MediatR;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;
using NewsAggregator.News.Web.Http;

namespace NewsAggregator.News.UseCases.Commands
{
    public class TestSearchNewsCommand : IRequest<IReadOnlyCollection<string>>
    {
        public string NewsSiteUrl { get; }

        public string NewsUrlXPath { get; }

        public TestSearchNewsCommand(string newsSiteUrl, string newsUrlXPath)
        {
            NewsSiteUrl = newsSiteUrl;
            NewsUrlXPath = newsUrlXPath;
        }

        public class Validator : AbstractValidator<TestSearchNewsCommand>
        {
            public Validator()
            {
                RuleFor(command => command.NewsSiteUrl).NotEmpty();
                RuleFor(command => command.NewsUrlXPath).NotEmpty();
            }
        }

        internal class Handler : IRequestHandler<TestSearchNewsCommand, IReadOnlyCollection<string>>
        {
            private readonly INewsUrlsParser _parser;
            private readonly INewsListHtmlPageProvider _newsListHtmlPageProvider;

            public Handler(INewsUrlsParser parser, INewsListHtmlPageProvider newsListHtmlPageProvider)
            {
                _parser = parser;
                _newsListHtmlPageProvider = newsListHtmlPageProvider;
            }

            public async Task<IReadOnlyCollection<string>> Handle(TestSearchNewsCommand request, 
                CancellationToken cancellationToken)
            {
                var html = await _newsListHtmlPageProvider.ProvideAsync(request.NewsSiteUrl, 
                    cancellationToken);

                return await _parser.ParseAsync(request.NewsSiteUrl, html,
                    new NewsUrlsParserOptions(request.NewsUrlXPath), cancellationToken);
            }
        }
    }
}
