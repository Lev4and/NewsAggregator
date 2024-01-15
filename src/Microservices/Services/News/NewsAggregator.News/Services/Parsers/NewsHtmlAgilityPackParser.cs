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
                var parsedNewsSubTitle = htmlDocumentNavigator
                    ?.SelectSingleNode(options.SubTitleXPath)?.Value?.Trim();

                newsSubTitle = options.IsSubTitleRequired
                    ? parsedNewsSubTitle ?? throw new NullReferenceException(nameof(parsedNewsSubTitle))
                    : parsedNewsSubTitle;
            }

            var newsPictureUrl = null as string;

            if (!string.IsNullOrEmpty(options.PictureUrlXPath))
            {
                var parsedNewsPictureUrl = htmlDocumentNavigator
                    ?.SelectSingleNode(options.PictureUrlXPath)?.Value?.Trim();

                newsPictureUrl = options.IsPictureUrlRequired
                    ? parsedNewsPictureUrl ?? throw new NullReferenceException(nameof(parsedNewsPictureUrl))
                    : parsedNewsPictureUrl;
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
                var parsedNewsEditorName = htmlDocumentNavigator
                    ?.SelectSingleNode(options.EditorNameXPath)?.Value?.Trim();

                newsEditorName = options.IsEditorNameRequired
                    ? parsedNewsEditorName ?? throw new NullReferenceException(nameof(parsedNewsEditorName))
                    : parsedNewsEditorName;
            }

            var newsPublishedAt = null as DateTime?;

            if (!string.IsNullOrEmpty(options.PublishedAtXPath) && !string.IsNullOrEmpty(options.PublishedAtFormat)
                && !string.IsNullOrEmpty(options.PublishedAtCultureInfo))
            {
                var parsedNewsPublishedAt = DateTime.UnixEpoch;

                var isParsedNewsPublishedAt = DateTime.TryParseExact(
                    htmlDocumentNavigator?.SelectSingleNode(options.PublishedAtXPath)?.Value?.Trim() ?? "", 
                    options.PublishedAtFormat, new CultureInfo(
                    options.PublishedAtCultureInfo), 
                    DateTimeStyles.None, 
                    out parsedNewsPublishedAt);

                newsPublishedAt = options.IsPublishedAtRequired
                    ? isParsedNewsPublishedAt
                        ? parsedNewsPublishedAt.ToUniversalTime()
                        : throw new NullReferenceException(nameof(parsedNewsPublishedAt))
                    : null;
            }

            return new NewsDto(newsUrl, newsTitle, newsSubTitle, newsEditorName, newsPictureUrl, 
                newsDescription, newsPublishedAt);
        }
    }
}
