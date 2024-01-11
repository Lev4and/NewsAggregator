using HtmlAgilityPack;
using NewsAggregator.News.Services.Parsers;
using Xunit.Abstractions;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsUrlsParserTests
    {
        private readonly ITestOutputHelper _output;
        private readonly INewsUrlsParser _parser;

        public NewsUrlsParserTests(ITestOutputHelper output)
        {
            _output = output;
            _parser = new NewsUrlsParser(new HtmlWeb());
        }

        [Theory]
        [ClassData(typeof(NewsUrlsParserTestsData.NewsSources))]
        public async Task ParseAsync_WithParams_ReturnNotEmptyResult(string newsSiteUrl, NewsUrlsParserOptions options)
        {
            var urls = await _parser.ParseAsync(newsSiteUrl, options);

            Assert.NotEmpty(urls);

            _output.WriteLine($"Found {urls.Count} news urls");

            foreach (var url in urls) 
            {
                _output.WriteLine(url);
            }
        }
    }
}
