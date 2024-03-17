using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class KhlNewsSource : NewsSource
    {
        public KhlNewsSource()
        {
            Id = Guid.Parse("9519622d-50f0-4a8d-8728-c58c12255b6f");
            Title = "КХЛ";
            SiteUrl = "https://www.khl.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("b22f3762-d5d6-4102-9817-a719bb0c220c"),
                Small = "https://www.khl.ru/img/icons/32x32.png",
                Original = "https://www.khl.ru/img/icons/152x152.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("683efe05-2dee-444a-95e9-5f23909ef186"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("06253ef3-b019-488a-a553-9da5fafb3ac1"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("931d85e9-49d4-44dd-b062-d8c7ce5d241a"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.SportNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("89efc9f8-a1a8-4ca4-accb-72741ca89d18"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.HockeyNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("c3d9032b-5b1b-4c67-9267-fcf6a890a660"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.KhlNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("a03ca9fd-6e2d-4da5-9017-5feb6a9a1404"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]",
                TextDescriptionXPath = "//div[@class='newsDetail-content__info']/*[not(name()='h1') and not(name()='h5')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("a811b3a1-c233-4875-9930-b99032c4fe99"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("9dc5c8f6-835a-44c5-bb98-2d988cd7001d"),
                    NameXPath = "//div[@class='newsDetail-body__item-header']/a[contains(@class, 'newsDetail-person')]//p[contains(@class, 'newsDetail-person__info-name')]/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("99e62b88-dd05-4581-a2e1-eb1f2616a05f"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("d3c31d01-f7fd-42e6-8378-3df623d1fc09"),
                    PublishedAtXPath = "//div[@class='newsDetail-body__item-subHeader']/time/text()",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("9b3343e0-5099-4696-a6b4-c00035cc78b3"),
                            Format = "d MMMM yyyy, HH:mm"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("d6c237fe-b4c2-47b1-918f-298f4a9eafdf"),
                NewsUrlXPath = "//a[starts-with(@href, '/news/') and contains(@href, '.html')]/@href",
                NewsSiteUrl = "https://www.khl.ru/news/"
            };
        }
    }
}
