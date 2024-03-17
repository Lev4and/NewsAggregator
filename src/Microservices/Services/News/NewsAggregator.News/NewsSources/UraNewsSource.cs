using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class UraNewsSource : NewsSource
    {
        public UraNewsSource()
        {
            Id = Guid.Parse("e16286a8-78a9-4b86-ba4b-c844f7099336");
            Title = "Ura.ru";
            SiteUrl = "https://ura.news/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("8db8aa26-06f6-4ebf-b2f6-81a02a20a288"),
                Small = "https://s.ura.news/favicon.ico?3",
                Original = "https://ura.news/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("1e00ba56-95e3-41d7-8eb0-fb2a839faf9c"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("f28044d3-15c7-4bee-9b92-8b418e03a191"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("9f83d191-c57f-4c08-bdf9-6b0c97b8367c"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("d477dceb-5655-432b-8bca-b2ca2d944d87"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='div')]",
                TextDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='div')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("c4ac25c5-d5da-4126-b298-8803c12b4930"),
                    TitleXPath = "//meta[@itemprop='description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("6d70075b-0b7b-4da3-8e5b-a312f268a3a9"),
                    NameXPath = "//div[@itemprop='author']/span[@itemprop='name']/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("fc8fc0b9-ccd3-4dcf-9b07-1e7031097188"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("3f29a12c-5e1c-45de-bf8b-96897f8ac962"),
                    PublishedAtXPath = "//div[@class='publication-info']/time[@itemprop='datePublished']/@datetime",
                    PublishedAtCultureInfo = "ru-RU",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("0b9c2546-034c-44d5-b328-fc29b3b96db4"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("62c58603-8696-4a94-bd69-de1938895b9b"),
                NewsSiteUrl = "https://ura.news/",
                NewsUrlXPath = "//a[contains(@href, '/news/')]/@href"
            };
        }
    }
}
