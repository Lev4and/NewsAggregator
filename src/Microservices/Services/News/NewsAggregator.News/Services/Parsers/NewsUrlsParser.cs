using HtmlAgilityPack;
using System.Linq;

namespace NewsAggregator.News.Services.Parsers
{
    public class NewsUrlsParser : INewsUrlsParser
    {
        private readonly HtmlWeb _htmlWeb;

        public NewsUrlsParser(HtmlWeb htmlWeb)
        {
            _htmlWeb = htmlWeb;
        }

        public async Task<IReadOnlyCollection<string>> ParseAsync(string newsSiteUrl, NewsUrlsParserOptions options,
            CancellationToken cancellationToken = default)
        {
            var newsSiteUri = new Uri(newsSiteUrl);
            var htmlDocument = await _htmlWeb.LoadFromWebAsync(newsSiteUrl, cancellationToken);

            return htmlDocument.DocumentNode.SelectNodes(options.NewsUrlXPath)
                .Select(node => node.Attributes["href"].Value)
                .Select(newsUrl => !newsUrl.Contains(newsSiteUri.Host) 
                    ? $"{newsSiteUri.Scheme}://{newsSiteUri.Host}/{newsUrl.Substring(1)}"
                    : newsUrl)
                .ToList();
        }
    }
}
