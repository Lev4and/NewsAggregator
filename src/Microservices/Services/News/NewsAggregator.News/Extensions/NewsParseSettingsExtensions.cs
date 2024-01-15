using MongoDB.Driver;
using NewsAggregator.News.Databases.EntityFramework.News.Entities;
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
                EditorNameXPath = settings.ParseEditorSettings?.NameXPath,
                IsEditorNameRequired = settings.ParseEditorSettings?.IsRequired ?? false,
                PublishedAtXPath = settings.ParsePublishedAtSettings?.PublishedAtXPath,
                PublishedAtFormat = settings.ParsePublishedAtSettings?.PublishedAtFormat,
                PublishedAtCultureInfo = settings.ParsePublishedAtSettings?.PublishedAtCultureInfo,
                IsPublishedAtRequired = settings.ParsePublishedAtSettings?.IsRequired ?? false,
            };
        }
    }
}
