using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class RadioSputnikNewsSource : NewsSource
    {
        public RadioSputnikNewsSource()
        {
            Id = Guid.Parse("1994c4bc-aeb9-4242-81df-5bafffca6fd0");
            Title = "Радио Sputnik";
            SiteUrl = "https://radiosputnik.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("e8db752b-966e-4c0f-9cab-895cda0de469"),
                Small = "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/favicon.ico",
                Original = "https://cdnn21.img.ria.ru/i/favicons/radiosputnik/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("4f09a167-0888-4ee7-9f0a-0cf691870de1"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("8477f4da-0bb6-4f77-9d5b-e8681d275e34"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("4b5473d0-5275-4615-94e2-596a86b383dd"),
                    Tag = new PoliticsNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("faddd74b-9234-4412-be8c-74b05ce04dc7"),
                    Tag = new RadioNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("dd419d1c-db40-4fd4-8f12-34206242d7cc"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'article__body')]/*",
                TextDescriptionXPath = "//div[contains(@class, 'article__body')]//*[not(name()='script')]/text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("cbcb009b-37f0-4cf5-882c-df9a9e7dc908"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("3dc22c77-8081-46cf-b981-fb88b2bfcece"),
                    NameXPath = "//meta[@property='article:author']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("b1ce7387-38c3-475c-a085-0984b9ba8b00"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("3785f3c0-c9d3-4e29-a0b8-46fa78983506"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("5b48664a-bb06-480d-bbd4-c7acebf918db"),
                            Format = "yyyyMMddTHHmm"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("458c1359-0212-451f-9c05-a6d043114989"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    ModifiedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("405dd507-6429-4fd3-a76f-7c211adbb18e"),
                            Format = "yyyyMMddTHHmm"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("112b8f16-4de2-4679-bed3-cf3c4ce5e1ed"),
                NewsUrlXPath = "//a[starts-with(@href, 'https://radiosputnik.ru/') and contains(@href, '.html')]/@href",
                NewsSiteUrl = "https://radiosputnik.ru/"
            };
        }
    }
}
