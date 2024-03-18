using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class LentaRuNewsSource : NewsSource
    {
        public LentaRuNewsSource()
        {
            Id = Guid.Parse("fb2f8557-ca7e-4ce2-86dd-b8a94ee02275");
            Title = "Лента.Ру";
            SiteUrl = "https://lenta.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("ef6ba8cf-50e4-432b-9329-19097bff75e2"),
                Small = "https://icdn.lenta.ru/favicon.ico",
                Original = "https://icdn.lenta.ru/images/icons/icon-256x256.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("585e40dd-ec2b-41b6-b505-59603e1031f8"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("5178aad8-b861-4640-afc6-c3bd1749ae94"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("3e8627f0-f07d-4cab-a30b-08282bbdf928"),
                    Tag = new PoliticsNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("a39fd0cf-d695-451a-8ec5-b662eddf4e9e"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='topic-body__content']",
                TextDescriptionXPath = "//div[@class='topic-body__content']//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("6718a708-10eb-4943-be1b-5be29565414f"),
                    NameXPath = "//div[@class='topic-authors']/a[@class='topic-authors__author']/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("d5de3a68-32d4-4553-ae39-ad3eb1509cc5"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseVideoSettings = new NewsParseVideoSettings
                {
                    Id = Guid.Parse("55100c78-3692-482c-af91-808f1a4f29a4"),
                    UrlXPath = "//div[contains(@class, 'eagleplayer')]//video/@src",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("527db9fa-2e2a-4f4e-b9eb-b9055994211f"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("b2514b4f-e07a-44e1-977b-9013bd07ea0c"),
                    PublishedAtXPath = "//div[@class='topic-page__header']//a[contains(@class, 'topic-header__time')]/text()",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("013ad3fa-fc09-4bce-a62a-5b23dfaf4b55"),
                            Format = "HH:mm, d MMMM yyyy"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("25667b44-614f-4c19-ad74-3be0c5f8c743"),
                NewsSiteUrl = "https://lenta.ru/",
                NewsUrlXPath = "//a[starts-with(@href, '/news/')]/@href"
            };
        }
    }
}
