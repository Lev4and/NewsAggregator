namespace NewsAggregator.News.Extensions
{
    public static class UriExtensions
    {
        public static string GetSiteUrl(this Uri url)
        {
            return $"{url.Scheme}://{url.Host}/";
        }

        public static string GetDomain(this Uri url) 
        {
            return string.Join('.', url.Host.Split('.').TakeLast(2));
        }
    }
}
