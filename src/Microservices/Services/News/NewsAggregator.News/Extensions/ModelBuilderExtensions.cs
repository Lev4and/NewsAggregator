using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsReactions;
using NewsAggregator.News.NewsSources;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static ModelBuilder AddDefaultData(this ModelBuilder modelBuilder)
        {
            var newsTags = new Tags();

            foreach (var newsTag in newsTags)
            {
                modelBuilder.AddNewsTag(newsTag);
            }

            var reactions = new Reactions();

            foreach (var reaction in reactions)
            {
                modelBuilder.AddReaction(reaction);
            }

            var newsSources = new Sources();

            foreach (var newsSource in newsSources)
            {
                modelBuilder.AddNewsSource(newsSource);
            }

            return modelBuilder;
        }

        private static ModelBuilder AddNewsTag(this ModelBuilder modelBuilder, NewsTag newsTag)
        {
            modelBuilder.Entity<NewsTag>().HasData(
                new NewsTag
                {
                    Id = newsTag.Id,
                    Name = newsTag.Name
                });

            return modelBuilder;
        }

        private static ModelBuilder AddReaction(this ModelBuilder modelBuilder, Reaction reaction)
        {
            modelBuilder.Entity<Reaction>().HasData(
                new Reaction
                {
                    Id = reaction.Id,
                    Title = reaction.Title
                });

            if (reaction.Icon is not null)
            {
                modelBuilder.Entity<ReactionIcon>().HasData(
                    new ReactionIcon
                    {
                        Id = reaction.Icon.Id,
                        ReactionId = reaction.Id,
                        IconClass = reaction.Icon.IconClass
                    });
            }

            return modelBuilder;
        }

        private static ModelBuilder AddNewsSource(this ModelBuilder modelBuilder, 
            NewsSource newsSource)
        {
            modelBuilder.Entity<NewsSource>().HasData(
                new NewsSource
                {
                    Id = newsSource.Id,
                    Title = newsSource.Title,
                    SiteUrl = newsSource.SiteUrl,
                    IsSystem = newsSource.IsSystem,
                    IsEnabled = newsSource.IsEnabled
                });

            if (!string.IsNullOrEmpty(newsSource.Logo?.Original))
            {
                newsSource.Logo.SourceId = newsSource.Id;

                modelBuilder.Entity<NewsSourceLogo>().HasData(new NewsSourceLogo
                {
                    Id = newsSource.Logo.Id,
                    SourceId = newsSource.Logo.SourceId,
                    Small = newsSource.Logo.Small,
                    Original = newsSource.Logo.Original
                });
            }

            if (newsSource.Tags is not null)
            {
                foreach (var newsSourceTag in newsSource.Tags) 
                {
                    if (newsSourceTag.Tag is not null)
                    {
                        newsSourceTag.SourceId = newsSource.Id;

                        modelBuilder.Entity<NewsSourceTag>().HasData(
                            new NewsSourceTag
                            {
                                Id = newsSourceTag.Id,
                                SourceId = newsSourceTag.SourceId,
                                TagId = newsSourceTag.Tag.Id
                            });
                    }
                }
            }

            if (newsSource.ParseSettings is not null)
            {
                newsSource.ParseSettings.SourceId = newsSource.Id;

                modelBuilder.Entity<NewsParseSettings>().HasData(
                    new NewsParseSettings
                    {
                        Id = newsSource.ParseSettings.Id,
                        SourceId = newsSource.ParseSettings.SourceId,
                        TitleXPath = newsSource.ParseSettings.TitleXPath,
                        HtmlDescriptionXPath = newsSource.ParseSettings.HtmlDescriptionXPath,
                        TextDescriptionXPath = newsSource.ParseSettings.TextDescriptionXPath
                    });

                if (!string.IsNullOrEmpty(newsSource.ParseSettings.ParseSubTitleSettings?.TitleXPath))
                {
                    newsSource.ParseSettings.ParseSubTitleSettings.ParseSettingsId = newsSource.ParseSettings.Id;

                    modelBuilder.Entity<NewsParseSubTitleSettings>().HasData(
                        new NewsParseSubTitleSettings
                        {
                            Id = newsSource.ParseSettings.ParseSubTitleSettings.Id,
                            ParseSettingsId = newsSource.ParseSettings.ParseSubTitleSettings.ParseSettingsId,
                            TitleXPath = newsSource.ParseSettings.ParseSubTitleSettings.TitleXPath,
                            IsRequired = newsSource.ParseSettings.ParseSubTitleSettings.IsRequired
                        });
                }

                if (!string.IsNullOrEmpty(newsSource.ParseSettings.ParsePictureSettings?.UrlXPath))
                {
                    newsSource.ParseSettings.ParsePictureSettings.ParseSettingsId = newsSource.ParseSettings.Id;

                    modelBuilder.Entity<NewsParsePictureSettings>().HasData(
                        new NewsParsePictureSettings
                        {
                            Id = newsSource.ParseSettings.ParsePictureSettings.Id,
                            ParseSettingsId = newsSource.ParseSettings.ParsePictureSettings.ParseSettingsId,
                            UrlXPath = newsSource.ParseSettings.ParsePictureSettings.UrlXPath,
                            IsRequired = newsSource.ParseSettings.ParsePictureSettings.IsRequired
                        });
                }

                if (!string.IsNullOrEmpty(newsSource.ParseSettings.ParseVideoSettings?.UrlXPath))
                {
                    newsSource.ParseSettings.ParseVideoSettings.ParseSettingsId = newsSource.ParseSettings.Id;

                    modelBuilder.Entity<NewsParseVideoSettings>().HasData(
                        new NewsParseVideoSettings
                        {
                            Id = newsSource.ParseSettings.ParseVideoSettings.Id,
                            ParseSettingsId = newsSource.ParseSettings.ParseVideoSettings.ParseSettingsId,
                            UrlXPath = newsSource.ParseSettings.ParseVideoSettings.UrlXPath,
                            IsRequired = newsSource.ParseSettings.ParseVideoSettings.IsRequired
                        });
                }

                if (!string.IsNullOrEmpty(newsSource.ParseSettings.ParseEditorSettings?.NameXPath))
                {
                    newsSource.ParseSettings.ParseEditorSettings.ParseSettingsId = newsSource.ParseSettings.Id;

                    modelBuilder.Entity<NewsParseEditorSettings>().HasData(
                        new NewsParseEditorSettings
                        {
                            Id = newsSource.ParseSettings.ParseEditorSettings.Id,
                            ParseSettingsId = newsSource.ParseSettings.ParseEditorSettings.ParseSettingsId,
                            NameXPath = newsSource.ParseSettings.ParseEditorSettings.NameXPath,
                            IsRequired = newsSource.ParseSettings.ParseEditorSettings.IsRequired
                        });
                }

                if (!string.IsNullOrEmpty(newsSource.ParseSettings.ParsePublishedAtSettings?.PublishedAtXPath) &&
                    !string.IsNullOrEmpty(newsSource.ParseSettings.ParsePublishedAtSettings?.PublishedAtCultureInfo))
                {
                    newsSource.ParseSettings.ParsePublishedAtSettings.ParseSettingsId = newsSource.ParseSettings.Id;

                    modelBuilder.Entity<NewsParsePublishedAtSettings>().HasData(
                        new NewsParsePublishedAtSettings
                        {
                            Id = newsSource.ParseSettings.ParsePublishedAtSettings.Id,
                            ParseSettingsId = newsSource.ParseSettings.ParsePublishedAtSettings.ParseSettingsId,
                            PublishedAtXPath = newsSource.ParseSettings.ParsePublishedAtSettings.PublishedAtXPath,
                            PublishedAtCultureInfo = newsSource.ParseSettings.ParsePublishedAtSettings.PublishedAtCultureInfo,
                            PublishedAtTimeZoneInfoId = newsSource.ParseSettings.ParsePublishedAtSettings.PublishedAtTimeZoneInfoId,
                            IsRequired = newsSource.ParseSettings.ParsePublishedAtSettings.IsRequired
                        });

                    if (newsSource.ParseSettings.ParsePublishedAtSettings.Formats?.Count > 0)
                    {
                        foreach (var format in newsSource.ParseSettings.ParsePublishedAtSettings.Formats)
                        {
                            format.NewsParsePublishedAtSettingsId = newsSource.ParseSettings.ParsePublishedAtSettings.Id;

                            modelBuilder.Entity<NewsParsePublishedAtSettingsFormat>().HasData(
                                new NewsParsePublishedAtSettingsFormat
                                {
                                    Id = format.Id,
                                    NewsParsePublishedAtSettingsId = format.NewsParsePublishedAtSettingsId,
                                    Format = format.Format
                                });
                        }
                    }
                }

                if (!string.IsNullOrEmpty(newsSource.ParseSettings.ParseModifiedAtSettings?.ModifiedAtXPath) &&
                    !string.IsNullOrEmpty(newsSource.ParseSettings.ParseModifiedAtSettings?.ModifiedAtCultureInfo))
                {
                    newsSource.ParseSettings.ParseModifiedAtSettings.ParseSettingsId = newsSource.ParseSettings.Id;

                    modelBuilder.Entity<NewsParseModifiedAtSettings>().HasData(
                        new NewsParseModifiedAtSettings
                        {
                            Id = newsSource.ParseSettings.ParseModifiedAtSettings.Id,
                            ParseSettingsId = newsSource.ParseSettings.ParseModifiedAtSettings.ParseSettingsId,
                            ModifiedAtXPath = newsSource.ParseSettings.ParseModifiedAtSettings.ModifiedAtXPath,
                            ModifiedAtCultureInfo = newsSource.ParseSettings.ParseModifiedAtSettings.ModifiedAtCultureInfo,
                            ModifiedAtTimeZoneInfoId = newsSource.ParseSettings.ParseModifiedAtSettings.ModifiedAtTimeZoneInfoId,
                            IsRequired = newsSource.ParseSettings.ParseModifiedAtSettings.IsRequired
                        });

                    if (newsSource.ParseSettings.ParseModifiedAtSettings.Formats?.Count > 0)
                    {
                        foreach (var format in newsSource.ParseSettings.ParseModifiedAtSettings.Formats)
                        {
                            format.NewsParseModifiedAtSettingsId = newsSource.ParseSettings.ParseModifiedAtSettings.Id;

                            modelBuilder.Entity<NewsParseModifiedAtSettingsFormat>().HasData(
                                new NewsParseModifiedAtSettingsFormat
                                {
                                    Id = format.Id,
                                    NewsParseModifiedAtSettingsId = format.NewsParseModifiedAtSettingsId,
                                    Format = format.Format
                                });
                        }
                    }
                }
            }

            if (newsSource.SearchSettings is not null)
            {
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
