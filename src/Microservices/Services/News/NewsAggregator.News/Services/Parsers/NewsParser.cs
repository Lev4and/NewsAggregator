using HtmlAgilityPack;
using NewsAggregator.News.DTOs;
using System.Globalization;

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

            var newsTitle = htmlDocument.DocumentNode
                .SelectSingleNode(options.TitleXPath).InnerText;

            var newsSubTitle = null as string;

            if (!string.IsNullOrEmpty(options.SubTitleXPath))
            {
                newsSubTitle = htmlDocument.DocumentNode
                    .SelectSingleNode(options.SubTitleXPath).InnerText;
            }

            var newsPictureUrl = null as string;

            if (!string.IsNullOrEmpty(options.PictureUrlXPath))
            {
                newsPictureUrl = htmlDocument.DocumentNode
                    .SelectSingleNode(options.PictureUrlXPath).Attributes["src"].Value;
            }

            var newsDescription = null as string;

            if (!string.IsNullOrEmpty(options.DescriptionXPath))
            {
                newsDescription = htmlDocument.DocumentNode
                    .SelectSingleNode(options.DescriptionXPath).OuterHtml;
            }

            var newsEditorName = null as string;

            if (!string.IsNullOrEmpty(options.EditorNameXPath))
            {
                newsEditorName = htmlDocument.DocumentNode
                    .SelectSingleNode(options.EditorNameXPath).InnerText;
            }

            var newsPublishedAt = null as DateTime?;

            if (!string.IsNullOrEmpty(options.PublishedAtXPath) && !string.IsNullOrEmpty(options.PublishedAtFormat)
                && !string.IsNullOrEmpty(options.PublishedAtCultureInfo))
            {
                newsPublishedAt = DateTime.ParseExact(htmlDocument.DocumentNode
                    .SelectSingleNode(options.PublishedAtXPath).InnerText, options.PublishedAtFormat,
                        new CultureInfo(options.PublishedAtCultureInfo)).ToUniversalTime();
            }

            return new NewsDto(newsUrl, newsTitle, newsSubTitle, newsEditorName, newsPictureUrl, 
                newsDescription, newsPublishedAt);
        }
    }
}
