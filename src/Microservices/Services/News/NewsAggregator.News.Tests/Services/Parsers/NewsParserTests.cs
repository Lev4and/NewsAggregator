using Xunit.Abstractions;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsParserTests
    {
        private readonly ITestOutputHelper _output;

        public NewsParserTests(ITestOutputHelper output)
        {
            _output = output;
        }
    }
}
