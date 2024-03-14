using NewsAggregator.Infrastructure.Web.Http;
using System.Net;
using System.Text;

namespace NewsAggregator.News.Web.Http
{
    public class NewsHttpClient : BaseHttpClient
    {
        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>()
        {
            { "Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;" +
                "q=0.8,application/signed-exchange;v=b3;q=0.7" },
            { "Accept-Encoding", "gzip, deflate, br" },
            { "Cache-Control", "max-age=0" },
            { "Sec-Ch-Ua", "\"Chromium\";v=\"118\", \"YaBrowser\";v=\"23.11\", \"Not=A?Brand\";v=\"99\", \"Yowser\";v=\"2.5\"" },
            { "Sec-Ch-Ua-Mobile", "?0" },
            { "Sec-Ch-Ua-Platform", "\"Windows\"" },
            { "Sec-Fetch-Dest", "document" },
            { "Sec-Fetch-Mode", "navigate" },
            { "Sec-Fetch-Site", "none" },
            { "Sec-Fetch-User", "?1" },
            { "Upgrade-Insecure-Requests", "1" },
            { "User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/118.0.0.0 " +
                "YaBrowser/23.11.0.0 Safari/537.36" }
        };

        public NewsHttpClient() : base()
        {
            UseHeaders(_headers);

            Timeout = new TimeSpan(0, 0, 5);
        }

        public async Task<string> GetHtmlAsync(string requestUri, CancellationToken cancellationToken = default)
        {
            var response = await GetAsync(requestUri, cancellationToken);

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }
    }
}
