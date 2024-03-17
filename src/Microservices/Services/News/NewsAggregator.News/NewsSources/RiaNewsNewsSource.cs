using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class RiaNewsNewsSource : NewsSource
    {
        public RiaNewsNewsSource()
        {
            Id = Guid.Parse("b8d20577-6c4c-4bd7-a1b1-b58bb4914541");
            Title = "РИА Новости";
            SiteUrl = "https://ria.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("a0faaf8f-34af-43f7-af18-782f9c6214d4"),
                Small = "https://cdnn21.img.ria.ru/i/favicons/favicon.ico",
                Original = "https://cdnn21.img.ria.ru/i/favicons/favicon.svg"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("aec9b965-2433-4bf0-ac3d-0f01775a6a75"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("b246f291-1cb3-42fc-904c-fdca50162d28"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("3f0c3643-d21d-4e8e-bf55-a01b42011215"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("9d11efde-ae9c-42a7-ac57-649bf5891e8a"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'article__body')]",
                TextDescriptionXPath = "//div[contains(@class, 'article__body')]//text()",
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("28112804-6fee-47fe-ad2e-9cdf4e982a82"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseVideoSettings = new NewsParseVideoSettings
                {
                    Id = Guid.Parse("f3733384-2b0f-4b5e-bf44-040e6452b896"),
                    UrlXPath = "//div[@class='article__header']//div[@class='media__video']//video/@src",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("5118a64e-b1fe-4226-b0f6-da9d0eb13ed0"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("b5afbf6f-9a28-4814-8ec0-80b43048c284"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("fdae85e3-de1e-4d29-a496-fa6ffedc616a"),
                            Format = "yyyyMMddTHHmm"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("3c897305-c4ad-42b1-9cb8-a550d075139c"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("c4c8a06a-a104-4e0e-87d1-4fa02bdfa36a"),
                            Format = "yyyyMMddTHHmm"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("bea34033-d382-4e18-9957-ad079cdb9a61"),
                NewsSiteUrl = "https://ria.ru/",
                NewsUrlXPath = "//a[contains(@class, 'cell-list__item-link')]/@href"
            };
        }
    }
}
