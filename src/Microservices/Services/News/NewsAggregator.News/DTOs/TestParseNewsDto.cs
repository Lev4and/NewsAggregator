using NewsAggregator.News.Services.Parsers;

namespace NewsAggregator.News.DTOs
{
    public class TestParseNewsDto
    {
        public string NewsUrl { get; set; }

        public NewsParserOptions ParserOptions { get; set; }
    }
}
