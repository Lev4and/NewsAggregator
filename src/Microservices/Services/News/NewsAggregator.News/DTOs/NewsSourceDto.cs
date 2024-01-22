using NewsAggregator.News.Services.Parsers;

namespace NewsAggregator.News.DTOs
{
    public class NewsSourceDto
    {
        public string Title { get; set; }

        public string SiteUrl { get; set; }

        public string NewsSiteUrl { get; set; }

        public string? LogoUrl { get; set; }

        public NewsParserOptions ParseSettings { get; set; }

        public NewsUrlsParserOptions SearchSettings { get; set; }
    }
}
