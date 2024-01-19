using NewsAggregator.News.Extensions;
using NewsAggregator.News.NewsSources;
using NewsAggregator.News.Services.Parsers;
using Xunit.Abstractions;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsParserTests
    {
        private readonly INewsParser _newsParser;
        private readonly INewsUrlsParser _newsUrlsParser;

        private readonly ITestOutputHelper _output;

        private readonly Sources _newsSources;

        public NewsParserTests(INewsParser newsParser, INewsUrlsParser newsUrlsParser, ITestOutputHelper output, 
            Sources newsSources)
        {
            _newsParser = newsParser;
            _newsUrlsParser = newsUrlsParser;

            _output = output;

            _newsSources = newsSources;
        }

        [Fact]
        public async Task ParseAsync_SpecificNewsSource_ReturnExpectedResult()
        {
            var foundNews = 0;
            var parsedNews = 0;

            var newsSource = _newsSources[new Uri("https://ura.news/")];

            if (newsSource.SearchSettings is null)
                throw new NullReferenceException(nameof(newsSource.SearchSettings));

            if (newsSource.ParseSettings is null)
                throw new NullReferenceException(nameof(newsSource.ParseSettings));

            var newsSiteUrl = newsSource.SearchSettings.NewsSiteUrl;
            var newsUrlsParserOptions = newsSource.SearchSettings.ToNewsUrlsParserOptions();

            var newsUrls = await _newsUrlsParser.ParseAsync(newsSiteUrl, newsUrlsParserOptions);

            foundNews += newsUrls.Count();

            foreach (var newsUrl in newsUrls)
            {
                try
                {
                    var newsParserOptions = newsSource.ParseSettings.ToNewsParserOptions();

                    await _newsParser.ParseAsync(newsUrl, newsParserOptions);

                    parsedNews += 1;
                }
                catch (Exception ex)
                {
                    _output.WriteLine("An error occurred when parse news {0}. Description: {1}.", newsUrl, ex.Message);
                }
            }

            var parsedNewsRate = (double)parsedNews / (double)foundNews;

            _output.WriteLine("\nParsed {0} of {1} news ({2:P5})", parsedNews, foundNews, parsedNewsRate);

            Assert.Equal(1, parsedNewsRate);
        }
    }
}
