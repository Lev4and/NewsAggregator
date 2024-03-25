using HtmlAgilityPack;
using NewsAggregator.News.Extensions;

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
                var newsUrl = item.ToString()?.Split('?').First() ?? "";

                if (newsUrl.StartsWith("/") && !newsUrl.StartsWith("//"))
                {
                    newsUrl = $"{newsSiteUri.GetSiteUrl()}{newsUrl.Substring(1)}";
                }

                if (newsUrl.StartsWith("//"))
                {
                    newsUrl = $"{newsSiteUri.Scheme}:{newsUrl}";
                }

                result.Add(newsUrl);
            }

            return Task.FromResult((IReadOnlyCollection<string>)result.Distinct().ToList());
        }
    }
}
