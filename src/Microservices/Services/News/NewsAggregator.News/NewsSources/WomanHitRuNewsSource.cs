using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class WomanHitRuNewsSource : NewsSource
    {
        public WomanHitRuNewsSource()
        {
            Id = Guid.Parse("2fa2ff6a-9a8b-4a2d-b0e4-6e7e14679236");
            Title = "Женский журнал WomanHit.ru";
            SiteUrl = "https://www.womanhit.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("1a1a5026-c9a6-4d74-9f36-721b47a79548"),
                Small = "https://www.womanhit.ru/static/front/img/favicon.ico?v=2",
                Original = "https://www.womanhit.ru/static/front/img/favicon.ico?v=2"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("e71cb8fe-52b0-4e6e-b344-0e5631996192"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("f0c920e4-64c9-4b1f-b3ce-780a1d0c34b3"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.WomanNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("a7d88817-12e6-434a-8c25-949dde2609f4"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//span[@itemprop='articleBody']/*",
                TextDescriptionXPath = "//span[@itemprop='articleBody']//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("45ebf04d-7b70-4c43-882d-af3d6ac3c687"),
                    TitleXPath = "//meta[@name='description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("e70fb7e3-35e6-4afa-ace8-b93a95bf5121"),
                    NameXPath = "//div[@class='article__announce-authors']/a[@itemprop='author']/span[@itemprop='name']/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("84f20ff4-fb12-45de-b7de-e9d7844f6935"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("f4df8c3f-efa8-4fa5-bb34-91942ecec22a"),
                    PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("7ff54b73-3ea0-49c6-9702-ad9fe746e1c9"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("75386858-8fad-48aa-bea8-d5aec36c1f8f"),
                    ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("4acbd680-8c5e-48a3-ae91-d66c2107150a"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("09a55b0c-4a3f-497c-9626-9b5b5e12ca26"),
                NewsUrlXPath = "//a[not(@href='/stars/news/') and starts-with(@href, '/stars/news/')]/@href",
                NewsSiteUrl = "https://www.womanhit.ru/"
            };
        }
    }
}
