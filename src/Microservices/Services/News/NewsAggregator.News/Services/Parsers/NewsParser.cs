using HtmlAgilityPack;
using NewsAggregator.News.DTOs;
using System.Globalization;
using System.Linq;

namespace NewsAggregator.News.Services.Parsers
{
    public class NewsParser : INewsParser
    {
        private readonly HtmlWeb _htmlWeb;

        public NewsParser(HtmlWeb htmlWeb)
        {
            _htmlWeb = htmlWeb;
        }

        public async Task<NewsDto> ParseAsync(string newsUrl, NewsParserOptions options, 
            CancellationToken cancellationToken = default)
        {
            var htmlDocument = await _htmlWeb.LoadFromWebAsync(newsUrl);
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
