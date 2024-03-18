using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class LifeNewsSource : NewsSource
    {
        public LifeNewsSource()
        {
            Id = Guid.Parse("170a9aef-a708-41a4-8370-a8526f2c055f");
            Title = "Life";
            SiteUrl = "https://life.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("53f0c42f-abe9-46e6-8c49-a4939e81be95"),
                Small = "https://life.ru/favicon-32%D1%8532.png",
                Original = "https://life.ru/appletouch/apple-icon-180%D1%85180.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("2d10c3ff-332e-46bb-a37b-0ca725ee91a1"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("c2535359-45dd-458c-9b5a-bf7991047d9b"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("e219d7a3-c5d4-4f54-a275-75c5bc9df4cb"),
                    Tag = new PoliticsNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("3373c5b8-57e2-402b-9dfb-a0ae19e92336"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]",
                TextDescriptionXPath = "//div[contains(@class, 'styles_bodyWrapper')]/div[not(@class)]//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("cae0e909-1bff-4b11-8c86-70eff32fa743"),
                    NameXPath = "//div[contains(@class, 'styles_bodyWrapper')]//div[contains(@class, 'styles_authorsLinks')]/a/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("784347e1-cdbd-42dc-a71e-c0bf6dc1bd60"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("60431c05-e7a1-4c09-a2d3-940896b52565"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("4a335cad-bc2f-442e-9c89-74da04bbde90"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("715c49ba-24ae-40af-b0b5-cacd488cb00e"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("83f72716-09c4-4c46-97fc-255431a7f616"),
                NewsSiteUrl = "https://life.ru/s/novosti",
                NewsUrlXPath = "//a[contains(@href, '/p/')]/@href"
            };
        }
    }
}
