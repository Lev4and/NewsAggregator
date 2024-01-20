using AngleSharp.Html.Parser;
using BenchmarkDotNet.Attributes;
using NewsAggregator.News.Databases.EntityFramework.News.Entities;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.NewsSources;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;
using NewsAggregator.News.Web.Http;

namespace NewsAggregator.News.Benchmarks.Services.Parsers
{
    [MemoryDiagnoser]
    [SimpleJob(1, 10, 100)]
    public class NewsUrlsParserBenchmarks
    {
        private readonly NewsSource _newsSource;

        private readonly INewsListHtmlPageProvider _newsListHtmlPageProvider;

        private readonly NewsUrlsAngleSharpParser _newsUrlsAngleSharpParser;
        private readonly NewsUrlsHtmlAgilityPackParser _newsUrlsHtmlAgilityPackParser;

        private string _newsListHtmlPage;

        public NewsUrlsParserBenchmarks()
        {
            _newsSource = new Sources()[new Uri("https://www.championat.com/")];

            _newsListHtmlPageProvider = new NewsListHtmlPageProvider(new NewsHttpClient());

            _newsUrlsAngleSharpParser = new NewsUrlsAngleSharpParser(new HtmlParser());
            _newsUrlsHtmlAgilityPackParser = new NewsUrlsHtmlAgilityPackParser();

            _newsListHtmlPage = string.Empty;
        }

        [GlobalSetup]
        public async Task SetupAsync()
        {
            _newsListHtmlPage = await _newsListHtmlPageProvider.ProvideAsync(_newsSource.SiteUrl);
        }

        [Benchmark]
        public async Task AngleSharp()
        {
            if (_newsSource.SearchSettings is null)
            {
                throw new NullReferenceException(nameof(_newsSource.SearchSettings));
            }

            await _newsUrlsAngleSharpParser.ParseAsync(_newsSource.SearchSettings.NewsSiteUrl, _newsListHtmlPage,
                _newsSource.SearchSettings.ToNewsUrlsParserOptions());
        }

        [Benchmark]
        public async Task HtmlAgilityPack()
        {
            if (_newsSource.SearchSettings is null)
            {
                throw new NullReferenceException(nameof(_newsSource.SearchSettings));
            }

            await _newsUrlsHtmlAgilityPackParser.ParseAsync(_newsSource.SearchSettings.NewsSiteUrl, _newsListHtmlPage,
                _newsSource.SearchSettings.ToNewsUrlsParserOptions());
        }
    }
}
