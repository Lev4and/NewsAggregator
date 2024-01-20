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
    public class NewsParserBenchmarks
    {
        private readonly string _newsUrl;
        private readonly NewsSource _newsSource;

        private readonly INewsHtmlPageProvider _newsHtmlPageProvider;

        private readonly NewsAngleSharpParser _newsAngleSharpParser;
        private readonly NewsHtmlAgilityPackParser _newsHtmlAgilityPackParser;

        private string _newsHtmlPage;

        public NewsParserBenchmarks()
        {
            _newsUrl = "https://www.championat.com/football/news-5402390-messi-i-di-mariya-mogut-sygrat-za-argentinu-na-olimpijskih-igrah-2024-v-parizhe.html";
            _newsSource = new Sources()[new Uri("https://www.championat.com/")];

            _newsHtmlPageProvider = new NewsHtmlPageProvider(new NewsHttpClient());

            _newsAngleSharpParser = new NewsAngleSharpParser(new HtmlParser());
            _newsHtmlAgilityPackParser = new NewsHtmlAgilityPackParser();

            _newsHtmlPage = string.Empty;
        }

        [GlobalSetup]
        public async Task SetupAsync()
        {
            _newsHtmlPage = await _newsHtmlPageProvider.ProvideAsync(_newsUrl);
        }

        [Benchmark]
        public async Task AngleSharp()
        {
            if (_newsSource.ParseSettings is null)
            {
                throw new NullReferenceException(nameof(_newsSource.ParseSettings));
            }

            await _newsAngleSharpParser.ParseAsync(_newsUrl, _newsHtmlPage,
                _newsSource.ParseSettings.ToNewsParserOptions());
        }

        [Benchmark]
        public async Task HtmlAgilityPack()
        {
            if (_newsSource.ParseSettings is null)
            {
                throw new NullReferenceException(nameof(_newsSource.ParseSettings));
            }

            await _newsHtmlAgilityPackParser.ParseAsync(_newsUrl, _newsHtmlPage,
                _newsSource.ParseSettings.ToNewsParserOptions());
        }
    }
}
