using NewsAggregator.News.Web.Http;

namespace NewsAggregator.News.Services.Providers
{
    public class HttpClientNewsListHtmlPageProvider : INewsListHtmlPageProvider
    {
        private readonly NewsHttpClient _httpClient;

        public HttpClientNewsListHtmlPageProvider(NewsHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> ProvideAsync(string url, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetUtf8StringAsync(url, cancellationToken);
        }
    }
}
