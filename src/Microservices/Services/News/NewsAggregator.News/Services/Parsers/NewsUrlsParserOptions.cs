namespace NewsAggregator.News.Services.Parsers
{
    public class NewsUrlsParserOptions
    {
        public string NewsUrlXPath { get; }

        public NewsUrlsParserOptions(string newsUrlXPath)
        {
            NewsUrlXPath = newsUrlXPath;
        }
    }
}
