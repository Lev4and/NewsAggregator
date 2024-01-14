using HtmlAgilityPack;
using NewsAggregator.News.Web.Http;

namespace NewsAggregator.News.Services.Parsers
{
    public class NewsUrlsHtmlAgilityPackParser : INewsUrlsParser
    {
        private readonly NewsHttpClient _httpClient;

        public NewsUrlsHtmlAgilityPackParser(NewsHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IReadOnlyCollection<string>> ParseAsync(string newsSiteUrl, NewsUrlsParserOptions options,
            CancellationToken cancellationToken = default)
        {
            var newsSiteUri = new Uri(newsSiteUrl);

            var html = await _httpClient.GetUtf8StringAsync(newsSiteUrl, cancellationToken);

            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);

            var htmlDocumentNavigator = htmlDocument.CreateNavigator();

            if (htmlDocumentNavigator is null)
            {
                throw new NullReferenceException(nameof(htmlDocumentNavigator));
            }

            var result = new List<string>();

            foreach (var item in htmlDocumentNavigator.Select(options.NewsUrlXPath))
            {
                var newsUrl = item.ToString() ?? "";

                result.Add(!newsUrl.Contains(newsSiteUri.Host)
                    ? $"{newsSiteUri.Scheme}://{newsSiteUri.Host}/{newsUrl.Substring(1)}"
                        : newsUrl);
            }

            return result;
        }
    }
}
