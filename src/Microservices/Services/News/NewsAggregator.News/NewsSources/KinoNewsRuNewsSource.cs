using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class KinoNewsRuNewsSource : NewsSource
    {
        public KinoNewsRuNewsSource()
        {
            Id = Guid.Parse("296270ec-026b-4011-83ff-1466ba577864");
            Title = "KinoNews.ru";
            SiteUrl = "https://www.kinonews.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("1aa24985-d52d-4f4e-8113-022a0216a2af"),
                Small = "https://www.kinonews.ru/favicon.ico",
                Original = "https://www.kinonews.ru/favicon.ico"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("eb0ca62c-bf7c-40c8-946d-fadfd107cffb"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("24eaf488-7213-4419-8f9e-edb3222c7004"),
                    Tag = new MovieNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("32cad97f-b071-4e24-bdc9-10e5e58cf99b"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='textart']/div[not(@class)]/*",
                TextDescriptionXPath = "//div[@class='textart']/div[not(@class)]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("9e43be0a-592d-4c1a-8525-9545d8fada04"),
                    TitleXPath = "//div[@class='block-page-new']/h2/text()",
                    IsRequired = false,
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("d577c838-8fed-45ba-850b-18bf437c06f3"),
                    NameXPath = "//meta[@property='article:author']/@content",
                    IsRequired = false,
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("f30aba5c-0d63-4f7b-9f68-1dc1629cd449"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false,
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("8bf5f85a-aba6-48a5-8704-3f6c4f51d9d1"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("699ff8c9-5f7e-4216-8e21-23627129bab9"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("a6f6a030-99b0-4828-af01-5c01d655be30"),
                NewsUrlXPath = "//a[contains(@href, '/news_') and not(contains(@href, 'comments')) and not(contains(@href, 'news_p'))]/@href",
                NewsSiteUrl = "https://www.kinonews.ru/news/"
            };
        }
    }
}
