using Xunit.Abstractions;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsUrlsParserTests
    {
        private readonly ITestOutputHelper _output;

        public NewsUrlsParserTests(ITestOutputHelper output)
        {
            _output = output;
        }

        public void ParseAsync_WithParams_ReturnNotEmptyResult()
        {

        }
    }
}
