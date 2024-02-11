namespace NewsAggregator.News.Extensions
{
    public static class UriExtensions
    {
        public static string GetSiteUrl(this Uri url)
        {
            return $"{url.Scheme}://{url.Host}/";
        }
    }
}
