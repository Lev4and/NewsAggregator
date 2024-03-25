using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class FontankaRuNewsSource : NewsSource
    {
        public FontankaRuNewsSource()
        {
            Id = Guid.Parse("068fb7bb-4b76-4261-bc9a-274625fe8890");
            Title = "ФОНТАНКА.ру";
            SiteUrl = "https://www.fontanka.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("872f13d3-d28d-44c4-bf38-ab69bb554e4a"),
                Small = "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-76-precomposed.png",
                Original = "https://www.fontanka.ru/static/assets/favicons/apple/apple-favicon-180.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("22aacfa5-7c90-4d6f-9b04-79805d6d01e3"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("4b63e46c-1f07-4dc7-8c63-2a8eab4fb054"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("674e3fd9-f4a8-4b81-9f11-4de28cc824dd"),
                    Tag = new SaintPetersburgNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("d36d75dc-add7-4e21-8a31-2f40f4033b14"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//section[@itemprop='articleBody']/*",
                TextDescriptionXPath = "//section[@itemprop='articleBody']//p//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("2656349d-0958-4779-a36a-cca96fe04b6a"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("b6c8fbce-f0fa-4d28-b166-8ee9efb9f04f"),
                    NameXPath = "//meta[@property='ajur:article:authors']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("b9639099-40e4-4346-93ed-1aa69d2fd95c"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("fdad3f1e-646d-4fe0-b46f-cf5a2d320981"),
                    PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("c66b5e6c-d604-4a55-b38f-f9ae415ecd1c"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("92324d14-49b0-409a-96e1-6a37a8691c6e"),
                NewsUrlXPath = "//section//ul/li//div[@class]/div[not(@class)]/a[starts-with(@href, '/') and not(contains(@href, 'all.comments.html')) and not(contains(@href, '?'))]/@href",
                NewsSiteUrl = "https://www.fontanka.ru/24hours_news.html"
            };
        }
    }
}
