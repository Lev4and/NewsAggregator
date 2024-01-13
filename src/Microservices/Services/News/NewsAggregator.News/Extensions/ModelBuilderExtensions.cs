using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.Databases.EntityFramework.News.Entities;

namespace NewsAggregator.News.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddNewsSources(this ModelBuilder modelBuilder)
        {
            var newsSources = new NewsSources.NewsSources();

            foreach (var newsSource in newsSources)
            {
                modelBuilder.AddNewsSource(newsSource);
            }

            return modelBuilder;
        }
        
        private static ModelBuilder AddNewsSource(this ModelBuilder modelBuilder, NewsSource newsSource)
        {
            newsSource.Id = Guid.NewGuid();

            modelBuilder.Entity<NewsSource>().HasData(
                new NewsSource
                {
                    Id = newsSource.Id,
                    Title = newsSource.Title,
                    SiteUrl = newsSource.SiteUrl
                });

            if (!string.IsNullOrEmpty(newsSource.Logo?.Url))
            {
                newsSource.Logo.Id = Guid.NewGuid();
                newsSource.Logo.SourceId = newsSource.Id;

                modelBuilder.Entity<NewsSourceLogo>().HasData(new NewsSourceLogo
                {
                    Id = newsSource.Logo.Id,
                    SourceId = newsSource.Logo.SourceId,
                    Url = newsSource.Logo.Url
                });
            }

            if (newsSource.ParseSettings is not null)
            {
                newsSource.ParseSettings.Id = Guid.NewGuid();
                newsSource.ParseSettings.SourceId = newsSource.Id;

                modelBuilder.Entity<NewsParseSettings>().HasData(
                    new NewsParseSettings
                    {
                        Id = newsSource.ParseSettings.Id,
                        SourceId = newsSource.ParseSettings.SourceId,
                        TitleXPath = newsSource.ParseSettings.TitleXPath,
                        DescriptionXPath = newsSource.ParseSettings.DescriptionXPath
                    });

                if (!string.IsNullOrEmpty(newsSource.ParseSettings.ParseSubTitleSettings?.TitleXPath))
                {
                    newsSource.ParseSettings.ParseSubTitleSettings.Id = Guid.NewGuid();
                    newsSource.ParseSettings.ParseSubTitleSettings.ParseSettingsId = newsSource.ParseSettings.Id;

                    modelBuilder.Entity<NewsParseSubTitleSettings>().HasData(
                        new NewsParseSubTitleSettings
                        {
                            Id = newsSource.ParseSettings.ParseSubTitleSettings.Id,
                            ParseSettingsId = newsSource.ParseSettings.ParseSubTitleSettings.ParseSettingsId,
                            TitleXPath = newsSource.ParseSettings.ParseSubTitleSettings.TitleXPath
                        });
                }

                if (!string.IsNullOrEmpty(newsSource.ParseSettings.ParsePictureSettings?.UrlXPath))
                {
                    newsSource.ParseSettings.ParsePictureSettings.Id = Guid.NewGuid();
                    newsSource.ParseSettings.ParsePictureSettings.ParseSettingsId = newsSource.ParseSettings.Id;

                    modelBuilder.Entity<NewsParsePictureSettings>().HasData(
                        new NewsParsePictureSettings
                        {
                            Id = newsSource.ParseSettings.ParsePictureSettings.Id,
                            ParseSettingsId = newsSource.ParseSettings.ParsePictureSettings.ParseSettingsId,
                            UrlXPath = newsSource.ParseSettings.ParsePictureSettings.UrlXPath
                        });
                }

                if (!string.IsNullOrEmpty(newsSource.ParseSettings.ParseEditorSettings?.NameXPath))
                {
                    newsSource.ParseSettings.ParseEditorSettings.Id = Guid.NewGuid();
                    newsSource.ParseSettings.ParseEditorSettings.ParseSettingsId = newsSource.ParseSettings.Id;

                    modelBuilder.Entity<NewsParseEditorSettings>().HasData(
                        new NewsParseEditorSettings
                        {
                            Id = newsSource.ParseSettings.ParseEditorSettings.Id,
                            ParseSettingsId = newsSource.ParseSettings.ParseEditorSettings.ParseSettingsId,
                            NameXPath = newsSource.ParseSettings.ParseEditorSettings.NameXPath
                        });
                }

                if (!string.IsNullOrEmpty(newsSource.ParseSettings.ParsePublishedAtSettings?.PublishedAtXPath) &&
                    !string.IsNullOrEmpty(newsSource.ParseSettings.ParsePublishedAtSettings?.PublishedAtFormat) &&
                    !string.IsNullOrEmpty(newsSource.ParseSettings.ParsePublishedAtSettings?.PublishedAtCultureInfo))
                {
                    newsSource.ParseSettings.ParsePublishedAtSettings.Id = Guid.NewGuid();
                    newsSource.ParseSettings.ParsePublishedAtSettings.ParseSettingsId = newsSource.ParseSettings.Id;

                    modelBuilder.Entity<NewsParsePublishedAtSettings>().HasData(
                        new NewsParsePublishedAtSettings
                        {
                            Id = newsSource.ParseSettings.ParsePublishedAtSettings.Id,
                            ParseSettingsId = newsSource.ParseSettings.ParsePublishedAtSettings.ParseSettingsId,
                            PublishedAtXPath = newsSource.ParseSettings.ParsePublishedAtSettings.PublishedAtXPath,
                            PublishedAtFormat = newsSource.ParseSettings.ParsePublishedAtSettings.PublishedAtFormat,
                            PublishedAtCultureInfo = newsSource.ParseSettings.ParsePublishedAtSettings.PublishedAtCultureInfo
                        });
                }
            }

            if (newsSource.SearchSettings is not null)
            {
                newsSource.SearchSettings.Id = Guid.NewGuid();
                newsSource.SearchSettings.SourceId = newsSource.Id;

                modelBuilder.Entity<NewsSearchSettings>().HasData(
                    new NewsSearchSettings
                    {
                        Id = newsSource.SearchSettings.Id,
                        SourceId = newsSource.SearchSettings.SourceId,
                        NewsSiteUrl = newsSource.SearchSettings.NewsSiteUrl,
                        NewsUrlXPath = newsSource.SearchSettings.NewsUrlXPath
                    });
            }

            return modelBuilder;
        }
    }
}
