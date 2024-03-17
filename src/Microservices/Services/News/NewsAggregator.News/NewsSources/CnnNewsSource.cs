using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class CnnNewsSource : NewsSource
    {
        public CnnNewsSource()
        {
            Id = Guid.Parse("5c3b0099-2a8a-49a5-8c68-d24ebc9fac07");
            Title = "CNN";
            SiteUrl = "https://edition.cnn.com/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("9f083bc5-a246-46d7-a2fe-eaa32d79a821"),
                Small = "https://edition.cnn.com/media/sites/cnn/favicon.ico",
                Original = "https://edition.cnn.com/media/sites/cnn/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("e9e871d8-2a97-4117-bdd3-99a28be03cad"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.EnglishNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("6225f6e1-2901-4727-8aa5-c34d46730169"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.UKNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("6db9856b-05fa-4036-b700-6f6288bc8318"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("5c40c521-5f8b-4fd2-984c-78c7a3e583bd"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.TVNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("2de49bdd-5c36-49ff-9a3b-a1f6ceb75e75"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                TextDescriptionXPath = "//div[@itemprop='articleBody']/*//text()",
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("3238cb06-5baa-4d87-a6a7-d3b826c1da59"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("f32f03ee-4548-4259-ac50-d791451cb1d7"),
                    TitleXPath = "//meta[@name='description']/@content",
                    IsRequired = false,
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("502c8f33-a803-4578-83b9-a024d2b92510"),
                    NameXPath = "//meta[@name='author']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("1fe09b4f-73bd-4979-8206-439489299a64"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = "en-US",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>()
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("fb9e24ab-9e5b-4641-ac8b-df59d34811d1"),
                            Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("033e507a-cb9d-403f-a8cb-48238e03607b"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = "en-US",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>()
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("ff02bb15-206e-4c8b-940e-c077740c4e8d"),
                            Format = "yyyy-MM-ddTHH:mm:ss.fffZ"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("d9bee236-e02e-4940-a97f-7aa259961369"),
                NewsUrlXPath = "//a[contains(@href, '.html')]/@href",
                NewsSiteUrl = "https://edition.cnn.com/"
            };
        }
    }
}
