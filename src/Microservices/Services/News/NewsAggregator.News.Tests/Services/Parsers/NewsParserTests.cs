using HtmlAgilityPack;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Services.Parsers;
using System.Diagnostics;
using Xunit.Abstractions;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsParserTests
    {
        private readonly ITestOutputHelper _output;
        private readonly Stopwatch _stopwatch;

        private readonly INewsParser _newsParser;
        private readonly INewsUrlsParser _newsUrlsParser;

        public NewsParserTests(ITestOutputHelper output)
        {
            _output = output;
            _stopwatch = new Stopwatch();

            _newsParser = new NewsParser(new HtmlWeb());
            _newsUrlsParser = new NewsUrlsParser(new HtmlWeb());
        }

        [Theory]
        [ClassData(typeof(NewsParserTestsData.NewsSources))]
        public async Task ParseAsync_WithParams_ReturnNotNullResult(NewsSourceDto newsSourceDto)
        {
            var urls = await _newsUrlsParser.ParseAsync(newsSourceDto.NewsSiteUrl, newsSourceDto.SearchSettings);

            var parsedNewsCount = 0;

            foreach (var url in urls)
            {
                try
                {
                    _output.WriteLine(url);

                    _stopwatch.Restart();

                    var news = await _newsParser.ParseAsync(url, newsSourceDto.ParseSettings);

                    _output.WriteLine("\n");
                    _output.WriteLine("Title: {0}", news.Title);
                    _output.WriteLine("SubTitle: {0}", news.SubTitle);
                    _output.WriteLine("EditorName: {0}", news.EditorName);
                    _output.WriteLine("PublishedAt: {0}", news.PublishedAt);

                    parsedNewsCount += 1;
                }
                catch (Exception ex) 
                {
                    _output.WriteLine("\n");
                    _output.WriteLine("An error occurred when parse: {0}", ex.Message);
                }
                finally
                {
                    _stopwatch.Stop();

                    _output.WriteLine("Parsed for {0}ms", _stopwatch.ElapsedMilliseconds);
                    _output.WriteLine("\n");
                }
            }

            _output.WriteLine("Parsed {0} of {1} ({2:P2})", parsedNewsCount, urls.Count,
                (double)parsedNewsCount / (double)urls.Count);
        }
    }
}
