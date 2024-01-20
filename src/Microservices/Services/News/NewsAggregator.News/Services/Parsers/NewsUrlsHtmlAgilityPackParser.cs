using HtmlAgilityPack;
using NewsAggregator.News.Web.Http;

namespace NewsAggregator.News.Services.Parsers
{
    public class NewsUrlsHtmlAgilityPackParser : INewsUrlsParser
    {
        public NewsUrlsHtmlAgilityPackParser()
        {

        }

        public async Task<IReadOnlyCollection<string>> ParseAsync(string newsSiteUrl, string html, 
            NewsUrlsParserOptions options, CancellationToken cancellationToken = default)
        {
            var newsSiteUri = new Uri(newsSiteUrl);

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
