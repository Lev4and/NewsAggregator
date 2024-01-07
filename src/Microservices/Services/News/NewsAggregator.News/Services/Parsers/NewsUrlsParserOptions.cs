namespace NewsAggregator.News.Services.Parsers
{
    public class NewsUrlsParserOptions
    {
        public string NewsUrlXPath { get; set; }

        public NewsUrlsParserOptions() : this("")
        {

        }

        public NewsUrlsParserOptions(string newsUrlXPath)
        {
            NewsUrlXPath = newsUrlXPath;
        }
    }
}
