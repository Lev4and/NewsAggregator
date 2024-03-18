using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class TsargradNewsSource : NewsSource
    {
        public TsargradNewsSource()
        {
            Id = Guid.Parse("3b8c9766-f5d5-44ec-a014-45ddce4a9a0c");
            Title = "Царьград";
            SiteUrl = "https://tsargrad.tv/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("a1e75a31-deae-4634-8bd8-eea983e60bfc"),
                Small = "https://tsargrad.tv/favicons/favicon-32x32.png?s2",
                Original = "https://tsargrad.tv/favicons/apple-touch-icon-180x180.png?s2"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("97b780f9-1854-4ee2-88f9-cc9027152826"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("745d9370-217a-4c3c-9289-215003e963f2"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("660485e7-ff2a-4375-979a-62769a8becfa"),
                    Tag = new PoliticsNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("4c29ab0b-01eb-466e-8dc3-fe05886f4332"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]",
                TextDescriptionXPath = "//div[@class='article__content']/*[not(contains(@class, 'article__title')) and not(contains(@class, 'article__intro'))]//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("5e370949-45e8-4537-8855-cba4ecc363b4"),
                    NameXPath = "//a[@class='article__author']/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("bb45ff0a-06f3-46ea-9921-c4f45270334e"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseVideoSettings = new NewsParseVideoSettings
                {
                    Id = Guid.Parse("4d2c5172-fc50-4854-bd47-44511c0fd763"),
                    UrlXPath = "//meta[@property='og:video']/@content",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("0f75da21-14e8-47a2-81e2-01c5e05b5f9f"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("a4130bc3-4c5f-451f-92f1-73e1c1745fc6"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("490ce35b-c2e5-4008-93f1-632720e22073"),
                            Format = "yyyy-MM-ddTHH:mmzzz"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("39d1b1e4-aa28-41b0-a55a-fffe8e406645"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("c18f4a2e-e149-4310-9311-f46c52acada0"),
                            Format = "yyyy-MM-ddTHH:mmzzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("27aa8343-30f4-40ef-a8ab-20d41e3097c4"),
                NewsSiteUrl = "https://tsargrad.tv/",
                NewsUrlXPath = "//a[contains(@class, 'news-item__link')]/@href"
            };
        }
    }
}
