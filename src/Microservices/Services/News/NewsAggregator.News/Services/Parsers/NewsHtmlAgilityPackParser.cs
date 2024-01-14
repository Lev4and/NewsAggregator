using HtmlAgilityPack;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Web.Http;
using System.Globalization;

namespace NewsAggregator.News.Services.Parsers
{
    public class NewsHtmlAgilityPackParser : INewsParser
    {
        private readonly NewsHttpClient _httpClient;

        public NewsHtmlAgilityPackParser(NewsHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<NewsDto> ParseAsync(string newsUrl, NewsParserOptions options, 
            CancellationToken cancellationToken = default)
        {
            var html = await _httpClient.GetUtf8StringAsync(newsUrl, cancellationToken);

            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);

            var htmlDocumentNavigator = htmlDocument.CreateNavigator();

            if (htmlDocumentNavigator is null)
            {
                throw new NullReferenceException(nameof(htmlDocumentNavigator));
            }

            var newsTitle = htmlDocumentNavigator?.SelectSingleNode(options.TitleXPath)
                ?.Value?.Trim() ?? "";

            var newsSubTitle = null as string;

            if (!string.IsNullOrEmpty(options.SubTitleXPath))
            {
                newsSubTitle = htmlDocumentNavigator
                    ?.SelectSingleNode(options.SubTitleXPath)?.Value?.Trim();
            }

            var newsPictureUrl = null as string;

            if (!string.IsNullOrEmpty(options.PictureUrlXPath))
            {
                newsPictureUrl = htmlDocumentNavigator
                    ?.SelectSingleNode(options.PictureUrlXPath)?.Value?.Trim();
            }

            var newsDescription = null as string;

            if (!string.IsNullOrEmpty(options.DescriptionXPath))
            {
                newsDescription = string.Join("",
                    htmlDocument.DocumentNode.SelectNodes(options.DescriptionXPath)
                        .Select(node => node.OuterHtml.Trim()));
            }

            var newsEditorName = null as string;

            if (!string.IsNullOrEmpty(options.EditorNameXPath))
            {
                newsEditorName = htmlDocumentNavigator
                    ?.SelectSingleNode(options.EditorNameXPath)?.Value?.Trim();
            }

            var newsPublishedAt = null as DateTime?;

            if (!string.IsNullOrEmpty(options.PublishedAtXPath) && !string.IsNullOrEmpty(options.PublishedAtFormat)
                && !string.IsNullOrEmpty(options.PublishedAtCultureInfo))
            {
                newsPublishedAt = DateTime.ParseExact(htmlDocumentNavigator
                    ?.SelectSingleNode(options.PublishedAtXPath)?.Value?.Trim() ?? "", options.PublishedAtFormat,
                        new CultureInfo(options.PublishedAtCultureInfo)).ToUniversalTime();
            }

            return new NewsDto(newsUrl, newsTitle, newsSubTitle, newsEditorName, newsPictureUrl, 
                newsDescription, newsPublishedAt);
        }
    }
}
