namespace NewsAggregator.News.DTOs
{
    public class NewsSourceDto
    {
        public string Title { get; }

        public string SiteUrl { get; }

        public NewsSourceDto(string title, string siteUrl)
        {
            Title = title;
            SiteUrl = siteUrl;
        }
    }
}
