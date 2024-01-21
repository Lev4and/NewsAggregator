using AngleSharp.Html.Parser;
using AngleSharp.XPath;

namespace NewsAggregator.News.Services.Parsers
{
    public class NewsUrlsAngleSharpParser : INewsUrlsParser
    {
        private readonly HtmlParser _parser;

        public NewsUrlsAngleSharpParser(HtmlParser parser)
        {
            _parser = parser;
        }

        public async Task<IReadOnlyCollection<string>> ParseAsync(string newsSiteUrl, string html, 
            NewsUrlsParserOptions options, CancellationToken cancellationToken = default)
        {
            var newsSiteUri = new Uri(newsSiteUrl);

            var htmlDocument = await _parser.ParseDocumentAsync(html, cancellationToken);

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
