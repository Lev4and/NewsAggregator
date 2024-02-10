using HtmlAgilityPack;

namespace NewsAggregator.News.Services.Parsers
{
    public class NewsUrlsHtmlAgilityPackParser : INewsUrlsParser
    {
        public Task<IReadOnlyCollection<string>> ParseAsync(string newsSiteUrl, string html, 
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

                newsUrl = newsUrl.Split('?').First();

                newsUrl = !newsUrl.Contains(newsSiteUri.Host.Replace("www.", ""))
                    ? $"{newsSiteUri.Scheme}://{newsSiteUri.Host}/{newsUrl.Substring(1)}"
                    : newsUrl;

                result.Add(newsUrl);
            }

            return Task.FromResult((IReadOnlyCollection<string>)result.Distinct().ToList());
        }
    }
}
