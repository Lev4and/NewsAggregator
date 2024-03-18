using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class TheNewYorkTimesNewsSource : NewsSource
    {
        public TheNewYorkTimesNewsSource()
        {
            Id = Guid.Parse("136c7569-601c-4f16-9ca4-bd14bfa8c16a");
            Title = "The New York Times";
            SiteUrl = "https://www.nytimes.com/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("e1eeadd2-6075-447a-8cda-0952e46496fc"),
                Small = "https://www.nytimes.com/vi-assets/static-assets/ios-default-homescreen-57x57-dark-b395ebcad5b63aff9285aab58e31035e.png",
                Original = "https://www.nytimes.com/vi-assets/static-assets/apple-touch-icon-28865b72953380a40aa43318108876cb.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("85583770-ceb5-4114-b5dd-b00cc6dcb199"),
                    Tag = new EnglishNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("934a294d-04fc-4f74-971c-1dac01b70086"),
                    Tag = new UsaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("f739b571-d14b-4366-8c75-4b39aadd24f7"),
                    Tag = new PoliticsNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("dd0ea6e1-0684-4a1e-b143-37bdb1ba7c5a"),
                    Tag = new NewYorkNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("3c4ef27a-3157-4eff-a441-1e409c4b6c34"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//section[@name='articleBody']/*",
                TextDescriptionXPath = "//section[@name='articleBody']/*//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("75075f9b-f14d-4720-8311-933ae0383523"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("a8742001-52bb-4beb-852c-913eff64dceb"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("48a9b834-59bb-4398-8526-318c506c58eb"),
                    NameXPath = "//span[@itemprop='name']/a/text()",
                    IsRequired = false,
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("ccc2a5c5-02fd-4a8d-ace5-7f41742f442b"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.EnglishUsaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("e0b7abad-a103-4050-92c5-36017a518376"),
                            Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("4adf1a9f-ac4c-4f17-932b-aac460d0d2f2"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = CultureInfoConstants.EnglishUsaCultureInfoName,
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("83158dac-180c-45f5-b13f-82b253c3f0be"),
                            Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("035b1374-e0cd-4b0a-a567-e0feff9852ff"),
                NewsUrlXPath = "//a[contains(@href, '.html')]/@href",
                NewsSiteUrl = "https://www.nytimes.com/"
            };
        }
    }
}
