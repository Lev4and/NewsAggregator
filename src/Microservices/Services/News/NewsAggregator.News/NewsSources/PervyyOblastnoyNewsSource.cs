using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class PervyyOblastnoyNewsSource : NewsSource
    {
        public PervyyOblastnoyNewsSource()
        {
            Id = Guid.Parse("70873440-0058-4669-aa74-352489f9e6da");
            Title = "Первый областной";
            SiteUrl = "https://www.1obl.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("68fa8065-fdc2-4e15-b2b1-3adb91d2d862"),
                Small = "https://www.1obl.ru/favicon-32x32.png",
                Original = "https://www.1obl.ru/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("0eedd3af-e5dd-45f7-af31-15b9dee5c89f"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("1536f46f-ea14-4fb8-b8d5-9aae924266ff"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("b3e5aec3-aee3-41a6-a797-e56c87d2f920"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.ChelyabinskNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("921d7c0a-c084-4188-b243-d08580f65142"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                TextDescriptionXPath = "//div[@itemprop='articleBody']/*//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("f28a4798-e796-400d-ab07-ddb5bb21be43"),
                    NameXPath = "//*[@itemprop='author']/*[@itemprop='name']//text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("baa19068-8f2f-445e-8450-27967074fac5"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false,
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("6996d64b-f805-4868-a6d1-6d287f568e83"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("c00312de-2ba3-4047-b80c-e5624577ad29"),
                    PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("b0dec36b-12b0-4ff1-af8c-7feff35137de"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("9980ee74-f655-40af-b44e-c9feb0e0bd40"),
                    ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("05acbeac-ea1d-41c7-b658-ab3971501e2b"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("5337753f-c43d-4ffa-b966-6e926c3a0a1c"),
                NewsSiteUrl = "https://www.1obl.ru/news/",
                NewsUrlXPath = "//a[starts-with(@href, '/news/') and not(contains(@href, '?'))]/@href"
            };
        }
    }
}
