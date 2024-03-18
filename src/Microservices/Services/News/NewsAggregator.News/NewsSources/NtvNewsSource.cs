using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class NtvNewsSource : NewsSource
    {
        public NtvNewsSource()
        {
            Id = Guid.Parse("6c5fe2d4-8547-4fb0-8966-d148f8d77af7");
            Title = "НТВ";
            SiteUrl = "https://www.ntv.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("4af4b3b2-ca3d-4421-976f-0406c515033a"),
                Small = "https://cdn-static.ntv.ru/images/favicons/favicon-32x32.png",
                Original = "https://cdn-static.ntv.ru/images/favicons/android-chrome-192x192.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("93013951-10cd-474a-834f-fa528a3fd95b"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("f075a7a6-561f-4cdf-b71e-dd7a1f8f960f"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("a3c4d53e-42e2-4639-a0e6-adb0ce838bdb"),
                    Tag = new PoliticsNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("a12d8fd1-873f-4ac7-b4c5-4bffc6cb3479"),
                    Tag = new TVNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("fa16a108-45c2-42e4-8323-b1f3ea3cdf46"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='news-content__body']//div[contains(@class, 'content-text')]/*",
                TextDescriptionXPath = "//div[@class='news-content__body']//div[contains(@class, 'content-text')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("7d88f1e1-8458-403d-8d83-3d076b4cedd4"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("0f72771a-3c4e-4a38-9ab5-fe96f01728af"),
                    NameXPath = "//meta[@property='author']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("a6d5c07c-a1a6-4b00-9b58-babe896712fb"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("cbe14234-0158-487c-b0c0-2117107b9a34"),
                    PublishedAtXPath = "//section[contains(@class, 'news-content')]/div[@class='content-top']//p[contains(@class, 'content-top__date')]/text()",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("c0377df6-a447-44bb-9698-cd37f084d4be"),
                            Format = "dd.MM.yyyy, HH:mm"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("6b670151-2211-4da1-9313-86e1d58c9893"),
                NewsUrlXPath = "//a[not(@href='/novosti/') and not(@href='/novosti/authors') and starts-with(@href, '/novosti/')]/@href",
                NewsSiteUrl = "https://www.ntv.ru/novosti/"
            };
        }
    }
}
