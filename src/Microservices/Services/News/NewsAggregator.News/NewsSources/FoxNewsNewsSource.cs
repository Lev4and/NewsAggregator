using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class FoxNewsNewsSource : NewsSource
    {
        public FoxNewsNewsSource()
        {
            Id = Guid.Parse("e5afb99f-47ff-4822-89fa-2ff8859a5c42");
            Title = "Fox News";
            SiteUrl = "https://www.foxnews.com/";
            IsEnabled = true;
            IsSystem = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("3cd265f4-637e-480c-8294-9d81d9027538"),
                Small = "https://static.foxnews.com/static/orion/styles/img/fox-news/favicons/favicon-32x32.png",
                Original = "https://static.foxnews.com/static/orion/styles/img/fox-news/favicons/apple-touch-icon-180x180.png"
            };
            Tags = new List<NewsSourceTag>()
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("0840963c-95b1-40c4-9806-a3f96a510b2f"),
                    Tag = new EnglishNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("48a9904d-be59-4aac-8abb-5959bbd10a36"),
                    Tag = new UsaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("291c690f-9a53-4ae0-9480-2475af09adeb"),
                    Tag = new PoliticsNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("526e62ee-b4d1-4575-ba8a-8ee1ba5a041c"),
                    Tag = new TVNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("00a974a4-e223-45fb-965e-97269039d94a"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='article-body']//div[contains(@class, 'paywall')]/*",
                TextDescriptionXPath = "//div[@class='article-body']//div[contains(@class, 'paywall')]//p/text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("ef3237fa-b43a-4deb-b9d1-2e0b64d98a2a"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("cb8f6ea0-5566-4656-a109-c2daadc5b5a0"),
                    NameXPath = "//meta[@name='dc.creator']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("e5f37d04-6aa1-4e5c-b850-387388d0c62e"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("21813794-9df2-4993-a696-a65ee04af666"),
                    PublishedAtXPath = "//meta[@name='dcterms.created']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.EnglishUsaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("5c71bd20-8b52-4291-89a4-8a54bb2e374b"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("48f6b66c-3b41-49fd-b4ec-d2d1e3ced579"),
                    ModifiedAtXPath = "//meta[@name='dcterms.modified']/@content",
                    ModifiedAtCultureInfo = CultureInfoConstants.EnglishUsaCultureInfoName,
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat> 
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("adad19a0-95c1-40ee-a691-b4a8bcbf18b7"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("5ef6d413-2916-4259-b2e1-6e5dc36f8e2c"),
                NewsUrlXPath = "//header[@class='info-header']/h3[@class='title']/a/@href",
                NewsSiteUrl = "https://www.foxnews.com/"
            };
        }
    }
}
