using NewsAggregator.News.Extensions;
using NewsAggregator.News.NewsSources;
using NewsAggregator.News.Services.Parsers;
using Xunit.Abstractions;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsUrlsParserTests
    {
        private readonly INewsUrlsParser _parser;
        private readonly ITestOutputHelper _output;

        private readonly Sources _newsSources;

        public NewsUrlsParserTests(INewsUrlsParser parser, ITestOutputHelper output, Sources newsSources)
        {
            _parser = parser;
            _output = output;

            _newsSources = newsSources;
        }

        [Fact]
        public async Task ParseAsync_SpecificNewsSource_ReturnNotEmptyResult()
        {
            var newsSource = _newsSources[new Uri("https://tsargrad.tv/")];

            if (newsSource.SearchSettings is null)
                throw new NullReferenceException(nameof(newsSource.SearchSettings));

            var newsSiteUrl = newsSource.SearchSettings.NewsSiteUrl;
            var newsUrlsParserOptions = newsSource.SearchSettings.ToNewsUrlsParserOptions();

            var newsUrls = await _parser.ParseAsync(newsSiteUrl, newsUrlsParserOptions);

            _output.WriteLine("Found {0} news", newsUrls.Count);

            Assert.NotEmpty(newsUrls);
        }

        [Fact]
        public async void ParseAsync_AllNewsSources_ShouldBeGreaterThanZeroFoundNews()
        {
            var foundNews = 0;

            foreach (var newsSource in _newsSources)
            {
                if (newsSource.SearchSettings is null)
                    throw new NullReferenceException(nameof(newsSource.SearchSettings));

                var newsSiteUrl = newsSource.SearchSettings.NewsSiteUrl;
                var newsUrlsParserOptions = newsSource.SearchSettings.ToNewsUrlsParserOptions();

                var newsUrls = await _parser.ParseAsync(newsSiteUrl, newsUrlsParserOptions);

                foundNews += newsUrls.Count;
            }

            _output.WriteLine("Found {0} news", foundNews);

            Assert.True(foundNews > 0);
        }

        [Theory]
        [ClassData(typeof(NewsUrlsParserTestsData.NewsSources))]
        public async void ParseAsync_EachNewsSources_ReturnNotEmptyResult(string newsSiteUrl, NewsUrlsParserOptions options,
            CancellationToken cancellationToken = default)
        {
            var newsUrls = await _parser.ParseAsync(newsSiteUrl, options, cancellationToken);

            _output.WriteLine("Found {0} news", newsUrls.Count);

            Assert.NotEmpty(newsUrls);
        }
    }
}
