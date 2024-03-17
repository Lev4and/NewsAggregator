using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class CybersportRuNewsSource : NewsSource
    {
        public CybersportRuNewsSource()
        {
            Id = Guid.Parse("797060c0-3b47-4654-9176-32d719baad69");
            Title = "Cybersport.ru";
            SiteUrl = "https://www.cybersport.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("375423fe-7b3a-4296-80f1-4072577524c0"),
                Small = "https://www.cybersport.ru/favicon-32x32.png",
                Original = "https://www.cybersport.ru/favicon-192x192.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("9c690333-2c73-4cfc-b113-b4feb4fbc30a"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("ab8a6089-a6b8-4031-934e-d296f8253fd3"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.CybersportNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("2753275a-efd1-41e9-84cd-8b5399cb2ea3"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.SportNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("11795391-d20d-48df-ab38-30f796737a43"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'js-mediator-article')]/*[position()>1]",
                TextDescriptionXPath = "//div[contains(@class, 'js-mediator-article')]/*[position()>1]//text()",
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("b28db8a4-5df8-4f99-9d5e-7013a3d053c8"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false,
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("051b16f3-07e7-49c7-ae63-d49e01d685e6"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false,
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("da19d28d-156b-47a0-868b-18f4ec0c8114"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("6c536ec8-3a65-4fa3-9862-f7744d5b1e1f"),
                            Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("da1fb28b-2afb-461a-9cf2-6e65a9c6963d"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("61f79112-d8a1-4562-8a1d-6f5e64928a50"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("f75f5b07-588f-4a4d-afb2-3558f99b54d7"),
                NewsSiteUrl = "https://www.cybersport.ru/",
                NewsUrlXPath = "//a[contains(@href, '/tags/')]/@href",
            };
        }
    }
}
