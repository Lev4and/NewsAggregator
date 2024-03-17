using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class SvobodnayaPressaNewsSource : NewsSource
    {
        public SvobodnayaPressaNewsSource()
        {
            Id = Guid.Parse("6854c858-b82d-44f5-bb48-620c9bf9825d");
            Title = "СвободнаяПресса";
            SiteUrl = "https://svpressa.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("1949e476-a28c-49c7-8cef-114ed2f70618"),
                Small = "https://svpressa.ru/favicon-32x32.png?v=1471426270000",
                Original = "https://svpressa.ru/favicon-96x96.png?v=1471426270000"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("95d32d18-c7c5-4749-8166-7d83d9ad9bf6"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("a02eecd4-f17b-42eb-beea-331873191aa9"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("151e6d99-9d03-4acb-8058-0f49bbb4a589"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("68faffa0-b7e6-44bb-a958-441eb532bfbb"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]",
                TextDescriptionXPath = "//div[@class='b-text__content']/div[contains(@class, 'b-text__block')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("e20418bb-871d-4c31-a56b-9038d36a37e1"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false,
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("ac6a9a56-dada-4c70-b614-1b8fa635a812"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("47aebca8-87d6-4241-81c5-a65b23518f8a"),
                    NameXPath = "//article//header//div[@class='b-authors']/div[@class='b-author' and position()=1]//text()",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("89fc1310-fff8-4cdc-aff5-c4285f9ab73c"),
                    PublishedAtXPath = "//div[@class='b-text__date']/text()",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("558de16f-ff6b-412c-9526-c6dd265565f4"),
                            Format = "d MMMM yyyy HH:mm"
                        },
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("d7afea6f-76d6-4684-86ce-f4d232f21786"),
                            Format = "d MMMM  HH:mm"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("beacb8f7-d53b-4785-a799-57b69c4cd3fc"),
                NewsSiteUrl = "https://svpressa.ru/all/news/",
                NewsUrlXPath = "//a[contains(@href, '/news/') and not(contains(@href, '?')) and not(starts-with(@href, '/all/news/'))]/@href"
            };
        }
    }
}
