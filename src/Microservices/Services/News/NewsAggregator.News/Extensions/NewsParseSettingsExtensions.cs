using MongoDB.Driver;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Services.Parsers;

namespace NewsAggregator.News.Extensions
{
    public static class NewsParseSettingsExtensions
    {
        public static NewsParserOptions ToNewsParserOptions(this NewsParseSettings settings)
        {
            return new NewsParserOptions
            {
                TitleXPath = settings.TitleXPath,
                DescriptionXPath = settings.DescriptionXPath,
                SubTitleXPath = settings.ParseSubTitleSettings?.TitleXPath,
                IsSubTitleRequired = settings.ParseSubTitleSettings?.IsRequired ?? false,
                PictureUrlXPath = settings.ParsePictureSettings?.UrlXPath,
                IsPictureUrlRequired = settings.ParsePictureSettings?.IsRequired ?? false,
                VideoUrlXPath = settings.ParseVideoSettings?.UrlXPath,
                IsVideoUrlRequired = settings.ParseVideoSettings?.IsRequired ?? false,
                EditorNameXPath = settings.ParseEditorSettings?.NameXPath,
                IsEditorNameRequired = settings.ParseEditorSettings?.IsRequired ?? false,
                PublishedAtXPath = settings.ParsePublishedAtSettings?.PublishedAtXPath,
                PublishedAtFormats = settings.ParsePublishedAtSettings?.Formats?.Select(format => format.Format).ToArray(),
                PublishedAtCultureInfo = settings.ParsePublishedAtSettings?.PublishedAtCultureInfo,
                PublishedAtTimeZoneInfoId = settings.ParsePublishedAtSettings?.PublishedAtTimeZoneInfoId,
                IsPublishedAtRequired = settings.ParsePublishedAtSettings?.IsRequired ?? false,
                ModifiedAtXPath = settings.ParseModifiedAtSettings?.ModifiedAtXPath,
                ModifiedAtFormats = settings.ParseModifiedAtSettings?.Formats?.Select(format => format.Format).ToArray(),
                ModifiedAtCultureInfo = settings.ParseModifiedAtSettings?.ModifiedAtCultureInfo,
                ModifiedAtTimeZoneInfoId = settings.ParseModifiedAtSettings?.ModifiedAtTimeZoneInfoId,
                IsModifiedAtRequired = settings.ParseModifiedAtSettings?.IsRequired ?? false
            };
        }
    }
}
