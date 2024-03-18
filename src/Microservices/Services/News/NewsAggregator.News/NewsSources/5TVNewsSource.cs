using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class _5TVNewsSource : NewsSource
    {
        public _5TVNewsSource()
        {
            Id = Guid.Parse("33b14253-7c02-4b79-8490-c8ed10312230");
            Title = "Пятый канал";
            SiteUrl = "https://www.5-tv.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("c4d13a4c-2f0d-41a4-a5e0-543e6a7dbad8"),
                Small = "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png",
                Original = "https://img5tv.cdnvideo.ru/shared/img/favicon_24.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("a12ba2dd-791c-44c0-963c-d0d0224f7aef"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("c55962cf-5967-4d67-a1a6-b2d1a856930b"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("0b335897-3cb8-4bd8-8e01-3435785fdc9c"),
                    Tag = new PoliticsNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("3a64826a-9a6f-4d7d-9798-1c86350846d1"),
                    Tag = new TVNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("5726d5dd-18ac-4c5c-a5d1-f775f1dd0b20"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@id='article_body']/*",
                TextDescriptionXPath = "//div[@id='article_body']//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("b96057cb-5a77-4785-a20d-c7bbb0c4752e"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("5b0a65b8-54c9-432e-8962-d3016e02c01e"),
                    NameXPath = "//meta[@name='article:author']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("0da669ee-feb9-4403-bc90-9af266fab309"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseVideoSettings = new NewsParseVideoSettings
                {
                    Id = Guid.Parse("5a25f140-9895-4deb-9e9e-d048799446d3"),
                    UrlXPath = "//meta[@property='og:video']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("f3f8cc16-9599-42fa-acea-c66be06e0d13"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("af484c5e-0924-4f42-bcc5-8c4407ea9a92"),
                            Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("c8cda125-f32f-492a-9d65-c1e0abb69300"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    ModifiedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("97301aa5-3306-4948-a4f9-0ad1c5d3cda0"),
                            Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("0bd7b701-63de-48e9-8494-4faf1193e218"),
                NewsUrlXPath = "//a[not(@href='https://www.5-tv.ru/news/') and starts-with(@href, 'https://www.5-tv.ru/news/')]/@href",
                NewsSiteUrl = "https://www.5-tv.ru/news/"
            };
        }
    }
}
