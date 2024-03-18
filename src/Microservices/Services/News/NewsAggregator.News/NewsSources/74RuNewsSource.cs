using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class _74RuNewsSource : NewsSource
    {
        public _74RuNewsSource()
        {
            Id = Guid.Parse("321e1615-6328-4532-85ac-22d53d59c164");
            Title = "74.ru";
            SiteUrl = "https://74.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("f3318dd0-6ed3-4b25-ab34-6f4330317853"),
                Small = "https://static.ngs.ru/jtnews/dist/static/favicons/favicon-rugion-32.ico",
                Original = "https://static.ngs.ru/jtnews/dist/static/favicons/apple/apple-favicon-74-180.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("9d6cd55b-f966-4e6a-973d-d548d7183da2"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("32ea560c-f4ef-4bb9-844c-72206f5f0e5f"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("cbc029ee-c8f0-493a-b9e7-837420e76734"),
                    Tag = new ChelyabinskNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("e4542056-2c68-43c6-a85c-9e4899556800"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='figure' and position()=1)]",
                TextDescriptionXPath = "//div[@itemprop='articleBody']/*[not(name()='figure') and not(lazyhydrate)]//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("ce13e4cd-82df-4d2b-87e1-9256c5ef8c7c"),
                    NameXPath = "//div[@itemprop='author']//p[@itemprop='name']/text()",
                    IsRequired = false,
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("64c04564-82ae-449f-9264-840c277b648c"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false,
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("7e4b4a81-f9e7-4830-9127-6fd86379db9a"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("79e88ebb-d542-4d19-a212-6c21f2688c77"),
                    PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("78b09bbf-a311-4d1a-9d00-d054898f1354"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("0a1fc27b-5f76-4a98-acd2-c3f98852d1c0"),
                    ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                    ModifiedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("3217adeb-8d21-4a5c-82df-83883177308f"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("e1e2fd1c-8939-4531-90b3-3a8879319fb9"),
                NewsSiteUrl = "https://74.ru/",
                NewsUrlXPath = "//a[starts-with(@href, '/text/') and not(contains(@href, '?')) and not(contains(@href, 'comments/')) and not(@href='/text/')]/@href"
            };
        }
    }
}
