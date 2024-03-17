using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class IzvestiaNewsSource : NewsSource
    {
        public IzvestiaNewsSource()
        {
            Id = Guid.Parse("31252741-4d0b-448f-b85c-d6538f7ca565");
            Title = "Известия";
            SiteUrl = "https://iz.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("a5431839-5bf7-46f6-a2eb-c93b4b18e24f"),
                Small = "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/favicon-32x32.png",
                Original = "https://cdn.iz.ru/profiles/portal/themes/purple/images/favicons/android-icon-192x192.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("a881440d-08a1-41e0-86a7-64b3dec4d5d4"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("fd0b4b8f-5731-4e4f-a96b-f80093af1630"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("6a065cf7-5a1e-445f-98d1-043b96aa75e8"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("9de1ef08-878b-4559-85af-a8b14d7ce68b"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                TextDescriptionXPath = "//div[@itemprop='articleBody']//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("d553ac3d-a4af-4359-9e9b-802bf0c62bcc"),
                    NameXPath = "//meta[@property='article:author']/@content",
                    IsRequired = false,
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("ee437f1b-e11b-48cd-9db5-645c3537edf1"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("8dfefc74-7200-46f5-94be-3fe0efa0894c"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("00106a66-61a0-4abd-b58e-9f9b4ed2c07d"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("d647a983-f4e1-4610-9ee7-5d8163fdd865"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("59699417-64ea-4f42-9573-68a21d4fdbe7"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("73cf32f0-bb16-4319-935b-76de58df264b"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("4c8ceb60-a498-4b5a-b574-a84b2d890e59"),
                NewsSiteUrl = "https://iz.ru/news/",
                NewsUrlXPath = "//a[contains(@href, '?main_click')]/@href"
            };
        }
    }
}
