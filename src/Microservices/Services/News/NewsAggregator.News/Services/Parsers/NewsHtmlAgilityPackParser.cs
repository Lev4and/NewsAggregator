﻿using HtmlAgilityPack;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using System.Globalization;

namespace NewsAggregator.News.Services.Parsers
{
    public class NewsHtmlAgilityPackParser : INewsParser
    {
        public NewsHtmlAgilityPackParser()
        {

        }

        public Task<NewsDto> ParseAsync(string newsUrl, string html, NewsParserOptions options, 
            CancellationToken cancellationToken = default)
        {
            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);

            var htmlDocumentNavigator = htmlDocument.CreateNavigator();

            if (htmlDocumentNavigator is null)
            {
                throw new NullReferenceException(nameof(htmlDocumentNavigator));
            }

            var newsTitle = htmlDocumentNavigator?.SelectSingleNode(options.TitleXPath)
                ?.Value?.Trim() ?? throw new NullReferenceException("newsTitle");

            var newsDescription = string.Join("", htmlDocument.DocumentNode.SelectNodes(options.DescriptionXPath)
                ?.Select(node => node.OuterHtml.Trim()) ?? throw new NullReferenceException("newsDescription"));

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

            var newsVideoUrl = null as string;

            if (!string.IsNullOrEmpty(options.VideoUrlXPath))
            {
                var parsedNewsVideoUrl = htmlDocumentNavigator
                    ?.SelectSingleNode(options.VideoUrlXPath)?.Value?.Trim();

                newsVideoUrl = options.IsVideoUrlRequired
                    ? parsedNewsVideoUrl ?? throw new NullReferenceException(nameof(parsedNewsVideoUrl))
                    : parsedNewsVideoUrl;
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

            var newsModifiedAt = null as DateTime?;

            if (!string.IsNullOrEmpty(options.ModifiedAtXPath) && !string.IsNullOrEmpty(options.ModifiedAtCultureInfo) &&
                options.ModifiedAtFormats?.Length > 0)
            {
                var parsedNewsModifiedAt = DateTime.UnixEpoch;

                var isParsedNewsModifiedAt = DateTime.TryParseExact(
                    htmlDocumentNavigator?.SelectSingleNode(options.ModifiedAtXPath)?.Value?.Trim() ?? "",
                    options.ModifiedAtFormats,
                    new CultureInfo(options.ModifiedAtCultureInfo),
                    DateTimeStyles.None,
                    out parsedNewsModifiedAt);

                newsModifiedAt = options.IsModifiedAtRequired
                    ? isParsedNewsModifiedAt
                        ? !string.IsNullOrEmpty(options.ModifiedAtTimeZoneInfoId)
                            ? TimeZoneInfo.ConvertTime(parsedNewsModifiedAt,
                                TimeZoneInfo.FindSystemTimeZoneById(options.ModifiedAtTimeZoneInfoId),
                                    TimeZoneInfo.Utc)
                            : parsedNewsModifiedAt.ToUniversalTime()
                        : throw new NullReferenceException(nameof(parsedNewsModifiedAt))
                    : null;
            }

            return Task.FromResult(new NewsDto(newsUrl, newsTitle, newsDescription, newsSubTitle, newsEditorName ?? NewsEditor.Empty,
                newsPictureUrl, newsVideoUrl, newsPublishedAt, newsModifiedAt, DateTime.UtcNow));
        }
    }
}
