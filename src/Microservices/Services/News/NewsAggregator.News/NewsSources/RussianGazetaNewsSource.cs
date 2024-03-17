using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class RussianGazetaNewsSource : NewsSource
    {
        public RussianGazetaNewsSource()
        {
            Id = Guid.Parse("31b6f068-3f00-4250-bc74-62146525ba95");
            Title = "Российская газета";
            SiteUrl = "https://rg.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("f1b5322f-8f12-4a8d-ba28-ee5aaed34228"),
                Small = "https://rg.ru/favicon.ico",
                Original = "https://cdnstatic.rg.ru/images/touch-icon-ipad-retina_512x512.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("5385f93d-42d7-4798-9868-d5c75a86fd8f"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("000a5ecc-fee2-486f-88de-ca43ce445849"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("33e60843-feb6-4f42-b171-b5dbd423ed3b"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("52014d82-bd2b-47fb-9ba1-668df2126197"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]",
                TextDescriptionXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]/*[not(name() = 'rg-video')]//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("8e018d32-828c-478d-a19f-8a06fd1fa797"),
                    NameXPath = "//div[contains(@class, 'PageArticleContent_authors')]//a[contains(@class, 'LinksOfAuthor_item')]/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("0ae45f17-84aa-42b2-801b-ff153d8d99b1"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseVideoSettings = new NewsParseVideoSettings
                {
                    Id = Guid.Parse("8bface35-e140-4937-8b51-06597bcfc862"),
                    UrlXPath = "//div[contains(@class, 'PageContentCommonStyling_text')]/rg-video//video/@src",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("f179e895-457c-4ccf-88ff-b4562edb1f33"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("e07f5d48-7c9a-4425-ae9f-788d26a63f23"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("bd0d7dc4-64d5-4daa-a89d-ca0609a09d29"),
                            Format = "yyyy-MM-ddTHH:mm:ss"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("90f502b6-e728-4f0a-b937-c264a9e683fd"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("a622e5c8-becb-44ac-809b-89da6191fa11"),
                            Format = "yyyy-MM-ddTHH:mm:ss"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("938c857a-640d-413d-98bf-1f5c1872dbae"),
                NewsSiteUrl = "https://rg.ru/",
                NewsUrlXPath = "//a[contains(@href, '.html')]/@href"
            };
        }
    }
}
