using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class RbcNewsSource : NewsSource
    {
        public RbcNewsSource()
        {
            Id = Guid.Parse("950d59d6-d94c-4396-a55e-cbcd2a9b533c");
            Title = "РБК";
            SiteUrl = "https://www.rbc.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("a77ffd9e-beb2-43d6-bf02-94ad9bc1eccd"),
                Small = "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/favicon.png",
                Original = "https://s.rbk.ru/v10_rbcnews_static/common/common-10.10.120/images/android-chrome-512x512.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("a1ba384a-04c5-4886-a113-36d86fc8cf60"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("75e4331e-76d5-48d0-998b-0765b6b7854d"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("c7585125-4dbc-4b56-aa3a-422a96ade9fb"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("929687ee-eb6f-4e95-852d-9635657d7f89"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]",
                TextDescriptionXPath = "//div[@class='article__text article__text_free']/*[not(contains(@class, 'article__text__overview')) and not(contains(@class, 'article__main-image'))]//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("9a6e6c25-1720-4eea-b8df-2195d32dfb46"),
                    NameXPath = "//div[@class='article__authors']//*[@class='article__authors__author']/span[@class='article__authors__author__name']/text()",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("07eddb61-de8e-46d8-ae6a-8f146d04e693"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("7ab23797-333a-428f-a8c2-620267ac2310"),
                    UrlXPath = "//meta[@itemprop='url']/@content",
                    IsRequired = false,
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("6f87ed33-a16c-465a-8784-33c69ef9bb0c"),
                    PublishedAtXPath = "//div[@class='article__header__info-block']/time[@class='article__header__date']/@datetime",
                    PublishedAtCultureInfo = "ru-RU",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("7a4a173c-cad8-4a09-adef-caecda7f5283"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("ffa17401-2b75-485d-a098-da254f125362"),
                    ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("06d2ec66-84f2-448c-808e-d5a50facb4cc"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("0f9c275f-d418-4fea-abbf-ad3cda6d678c"),
                NewsSiteUrl = "https://www.rbc.ru/",
                NewsUrlXPath = "//a[contains(@href, 'https://www.rbc.ru/') and contains(@href, '?from=')]/@href"
            };
        }
    }
}
