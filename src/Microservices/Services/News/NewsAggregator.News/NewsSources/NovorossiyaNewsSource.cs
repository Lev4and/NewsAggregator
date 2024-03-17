using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class NovorossiyaNewsSource : NewsSource
    {
        public NovorossiyaNewsSource()
        {
            Id = Guid.Parse("c7b863af-0565-4bec-9238-9383272637ef");
            Title = "Новороссия";
            SiteUrl = "https://www.novorosinform.org/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("bafc4c68-8558-46d1-b778-0c2137188d93"),
                Small = "https://www.novorosinform.org/favicon.ico?v3",
                Original = "https://www.novorosinform.org/favicon.ico?v3"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("95fe22e4-5977-4f74-947d-9cc8dba28f47"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("b27c172f-99b0-4441-a3a4-d499e302d509"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("a06bb1f8-a548-44b5-8d41-02af27aeeaf7"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("611bd50e-69f5-4598-8ad6-8b19771f1044"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='only__text']/*",
                TextDescriptionXPath = "//div[@class='only__text']/*[not(name()='script')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("eb234374-29cf-43b4-ae0f-5e8a80aaf132"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("62ed2534-e043-4f4d-a1ac-b9be0a4d9bbd"),
                    NameXPath = "//div[@class='article__content']//strong[text()='Автор:']/../text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("6f3531a6-db42-459a-ab24-08493edc3ac0"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("285b962c-f8e9-4b05-95e9-81a0ff26cd26"),
                NewsUrlXPath = "//a[contains(@href, '.html')]/@href",
                NewsSiteUrl = "https://www.novorosinform.org/"
            };
        }
    }
}
