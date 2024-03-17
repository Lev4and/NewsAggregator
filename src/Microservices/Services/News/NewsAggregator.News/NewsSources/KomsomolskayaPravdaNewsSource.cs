using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class KomsomolskayaPravdaNewsSource : NewsSource
    {
        public KomsomolskayaPravdaNewsSource()
        {
            Id = Guid.Parse("cb68ce1c-c741-41df-a1c9-8ce34529b421");
            Title = "Комсомольская правда";
            SiteUrl = "https://www.kp.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("4cf43716-885c-4a85-8d23-0ecc987da590"),
                Small = "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-32.png",
                Original = "https://s01.stc.yc.kpcdn.net/s0/2.1.321/adaptive/favicon-128.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("3442ffd8-d296-4f9a-8b56-e1c83a468053"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("d49cfbc4-2c58-4d27-b68c-6ead4192affc"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("b460f29d-8f45-4d10-9529-145c54287a6f"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("76b3ad9b-48c5-4f9e-ab28-993ba795fdb1"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]",
                TextDescriptionXPath = "//div[@data-gtm-el='content-body']/*[not(name()='div' and @data-wide='true')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("e68f6ef8-cd76-4fc8-b98b-cb2bc02c3dfd"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("375e4eca-f067-486a-a3cd-5045165dd9e1"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("d153a1fc-66c6-4313-adc9-36850ec82124"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("79934951-c9f9-4230-8eb5-2d3a80f4d4f4"),
                            Format = "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\""
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("700ffddc-d0a5-450a-b756-deabd7bfed18"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("fa45d026-0db8-4968-8753-da586b527e27"),
                            Format = "yyyy-MM-ddTHH:mm:ss.fff\"Z+0300\""
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("69765f00-a717-43b7-8c2e-59213979a3ed"),
                NewsUrlXPath = "//a[contains(@href, '/news/')]/@href",
                NewsSiteUrl = "https://www.kp.ru/"
            };
        }
    }
}
