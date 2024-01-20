using NewsAggregator.News.Web.Http;

namespace NewsAggregator.News.Services.Providers
{
    public class NewsHtmlPageProvider : INewsHtmlPageProvider
    {
        private readonly NewsHttpClient _httpClient;

        public NewsHtmlPageProvider(NewsHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ProvideAsync(string url, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetUtf8StringAsync(url, cancellationToken);
        }
    }
}
