using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.Databases.EntityFramework.News.Entities;
using NewsAggregator.News.DTOs;

namespace NewsAggregator.News.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddNewsSources(this ModelBuilder modelBuilder)
        {
            var newsSourceDtos = new NewsSourceDtos();

            foreach (var newsSourceDto in newsSourceDtos)
            {
                modelBuilder.AddNewsSource(newsSourceDto);
            }

            return modelBuilder;
        }
        
        private static ModelBuilder AddNewsSource(this ModelBuilder modelBuilder, NewsSourceDto newsSourceDto)
        {
            var newsSource = new NewsSource
            {
                Id = Guid.NewGuid(),
                Title = newsSourceDto.Title,
                SiteUrl = newsSourceDto.SiteUrl
            };

            modelBuilder.Entity<NewsSource>().HasData(newsSource);

            if (!string.IsNullOrEmpty(newsSourceDto.LogoUrl))
            {
                modelBuilder.Entity<NewsSourceLogo>().HasData(
                    new NewsSourceLogo
                    {
                        Id = Guid.NewGuid(),
                        SourceId = newsSource.Id,
                        Url = newsSourceDto.LogoUrl
                    });
            }

            var newsSourceParseSettings = new NewsParseSettings
            {
                Id = Guid.NewGuid(),
                SourceId = newsSource.Id,
                TitleXPath = newsSourceDto.ParseSettings.TitleXPath,
                DescriptionXPath = newsSourceDto.ParseSettings.DescriptionXPath
            };

            modelBuilder.Entity<NewsParseSettings>().HasData(newsSourceParseSettings);

            if (!string.IsNullOrEmpty(newsSourceDto.ParseSettings.SubTitleXPath))
            {
                modelBuilder.Entity<NewsParseSubTitleSettings>().HasData(
                    new NewsParseSubTitleSettings
                    {
                        Id = Guid.NewGuid(),
                        ParseSettingsId = newsSourceParseSettings.Id,
                        TitleXPath = newsSourceDto.ParseSettings.SubTitleXPath
                    });
            }

            if (!string.IsNullOrEmpty(newsSourceDto.ParseSettings.PictureUrlXPath))
            {
                modelBuilder.Entity<NewsParsePictureSettings>().HasData(
                    new NewsParsePictureSettings
                    {
                        Id = Guid.NewGuid(),
                        ParseSettingsId = newsSourceParseSettings.Id,
                        UrlXPath = newsSourceDto.ParseSettings.PictureUrlXPath
                    });
            }

            if (!string.IsNullOrEmpty(newsSourceDto.ParseSettings.EditorNameXPath))
            {
                modelBuilder.Entity<NewsParseEditorSettings>().HasData(
                    new NewsParseEditorSettings
                    {
                        Id = Guid.NewGuid(),
                        ParseSettingsId = newsSourceParseSettings.Id,
                        NameXPath = newsSourceDto.ParseSettings.EditorNameXPath
                    });
            }

            if (!string.IsNullOrEmpty(newsSourceDto.ParseSettings.PublishedAtXPath) && 
                !string.IsNullOrEmpty(newsSourceDto.ParseSettings.PublishedAtFormat) &&
                !string.IsNullOrEmpty(newsSourceDto.ParseSettings.PublishedAtCultureInfo))
            {
                modelBuilder.Entity<NewsParsePublishedAtSettings>().HasData(
                    new NewsParsePublishedAtSettings
                    {
                        Id = Guid.NewGuid(),
                        ParseSettingsId = newsSourceParseSettings.Id,
                        PublishedAtXPath = newsSourceDto.ParseSettings.PublishedAtXPath,
                        PublishedAtFormat = newsSourceDto.ParseSettings.PublishedAtFormat,
                        PublishedAtCultureInfo = newsSourceDto.ParseSettings.PublishedAtCultureInfo
                    });
            }

            modelBuilder.Entity<NewsSearchSettings>().HasData(
                new NewsSearchSettings
                {
                    Id = Guid.NewGuid(),
                    SourceId = newsSource.Id,
                    NewsSiteUrl = newsSourceDto.NewsSiteUrl,
                    NewsUrlXPath = newsSourceDto.SearchSettings.NewsUrlXPath
                });

            return modelBuilder;
        }
    }
}
