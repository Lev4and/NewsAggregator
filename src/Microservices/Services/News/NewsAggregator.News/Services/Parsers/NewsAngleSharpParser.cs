using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.XPath;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Web.Http;
using System.Globalization;

namespace NewsAggregator.News.Services.Parsers
{
    public class NewsAngleSharpParser : INewsParser
    {
        private readonly NewsHttpClient _httpClient;
        private readonly HtmlParser _parser;

        public NewsAngleSharpParser(NewsHttpClient httpClient, HtmlParser parser)
        {
            _httpClient = httpClient;
            _parser = parser;
        }

        public async Task<NewsDto> ParseAsync(string newsUrl, NewsParserOptions options, 
            CancellationToken cancellationToken = default)
        {
            var html = await _httpClient.GetUtf8StringAsync(newsUrl, cancellationToken);

            var htmlDocument = await _parser.ParseDocumentAsync(html, cancellationToken);

            var htmlDocumentNavigator = htmlDocument.CreateNavigator();

            if (htmlDocumentNavigator is null)
            {
                throw new NullReferenceException(nameof(htmlDocumentNavigator));
            }

            var newsTitle = htmlDocumentNavigator?.SelectSingleNode(options.TitleXPath)
                ?.Value?.Trim() ?? throw new NullReferenceException("newsTitle");

            var nodes = htmlDocument.Body.SelectNodes(options.DescriptionXPath);

            var newsDescription = string.Join("", htmlDocument.Body.SelectNodes(options.DescriptionXPath)
                ?.Select(node => ((IElement)node).OuterHtml.Trim()) ?? throw new NullReferenceException("newsDescription"));

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

            if (!string.IsNullOrEmpty(options.PublishedAtXPath) && !string.IsNullOrEmpty(options.PublishedAtCultureInfo) &&
                options.PublishedAtFormats?.Length > 0)
            {
                var parsedNewsPublishedAt = DateTime.UnixEpoch;

                var isParsedNewsPublishedAt = DateTime.TryParseExact(
                    htmlDocumentNavigator?.SelectSingleNode(options.PublishedAtXPath)?.Value?.Trim() ?? "",
                    options.PublishedAtFormats,
                    new CultureInfo(options.PublishedAtCultureInfo),
                    DateTimeStyles.None,
                    out parsedNewsPublishedAt);

                newsPublishedAt = options.IsPublishedAtRequired
                    ? isParsedNewsPublishedAt
                        ? !string.IsNullOrEmpty(options.PublishedAtTimeZoneInfoId)
                            ? TimeZoneInfo.ConvertTime(parsedNewsPublishedAt,
                                TimeZoneInfo.FindSystemTimeZoneById(options.PublishedAtTimeZoneInfoId),
                                    TimeZoneInfo.Utc)
                            : parsedNewsPublishedAt.ToUniversalTime()
                        : throw new NullReferenceException(nameof(parsedNewsPublishedAt))
                    : null;
            }

            return new NewsDto(newsUrl, newsTitle, newsDescription, newsSubTitle, newsEditorName,
                newsPictureUrl, newsPublishedAt);
        }
    }
}
