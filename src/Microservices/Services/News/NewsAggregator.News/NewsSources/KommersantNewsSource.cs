using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class KommersantNewsSource : NewsSource
    {
        public KommersantNewsSource()
        {
            Id = Guid.Parse("baaa533a-cb1a-46e7-bb9e-79d631affc87");
            Title = "Коммерсантъ";
            SiteUrl = "https://www.kommersant.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("52cd41a3-05b6-4ed0-87d0-bb62bd1a742a"),
                Small = "https://im.kommersant.ru/ContentFlex/images/favicons2020/favicon-32.png",
                Original = "https://im.kommersant.ru/ContentFlex/images/favicons2020/apple-touch-icon-180.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("ca9c9fa1-182d-416f-af3c-53b470edbbaa"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("6884348a-7db9-49b3-81db-8300d6e0d72e"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("6d9524d2-1101-493e-bd71-53d8ecf0e8de"),
                    Tag = new PoliticsNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("efd9bf27-abb2-46c2-bedb-dc7e745e55fb"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]",
                TextDescriptionXPath = "//div[@class='article_text_wrapper js-search-mark']/*[not(contains(@class, 'doc__text document_authors'))]//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("39793598-0239-4802-87f3-f04d404eee1c"),
                    NameXPath = "//p[@class='doc__text document_authors']/text()",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("b07f324a-9029-4214-8521-01187ec7376d"),
                    TitleXPath = "//meta[@name='description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("7c9e261c-a090-44f1-92b8-e4d0e6b1d9b5"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("47328c5f-5e86-4b2d-be25-fe9198a946fc"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("cdc7b365-0e9b-405d-b948-4c074942dcc3"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("25fa301c-d896-4a5e-b580-2dba44900fb6"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("d2673a76-54a4-4013-8596-c648d3e16aa7"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("465f7ae0-072e-4df3-8d24-7a194b478c2a"),
                NewsSiteUrl = "https://www.kommersant.ru/",
                NewsUrlXPath = "//a[contains(@href, '/doc/') and contains(@href, '?from=')]/@href"
            };
        }
    }
}
