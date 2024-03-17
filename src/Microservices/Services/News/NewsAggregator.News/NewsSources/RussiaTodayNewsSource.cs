using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class RussiaTodayNewsSource : NewsSource
    {
        public RussiaTodayNewsSource()
        {
            Id = Guid.Parse("5d8e3050-5444-4709-afc3-18a8d46a71ba");
            Title = "RT на русском";
            SiteUrl = "https://russian.rt.com/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("021335ce-8d6b-47fc-9de8-503f4c248982"),
                Small = "https://russian.rt.com/favicon.ico",
                Original = "https://russian.rt.com/static/blocks/touch-icon/apple-touch-icon-144x144-precomposed.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("4cac9f6e-f034-4600-8272-a04aeca7f0b4"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("dd4ff481-d8d3-410d-ad32-e39cf572071d"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("c549c18b-8e40-4196-b6d7-ff9c9cb516ba"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("da641510-f1dd-4fce-b895-cbf32dca79bf"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'article__text ')]",
                TextDescriptionXPath = "//div[contains(@class, 'article__text ')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("0c0b371b-5c93-4577-b625-7d520237ce5d"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("3b81d060-ce40-45bb-8ceb-81c10e88e2a8"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("e1a6a4f1-57ab-48e6-aaee-b9ece2104cf3"),
                    NameXPath = "//meta[@name='mediator_author']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("a17cf1af-be32-4074-9b36-6f5481ecbf14"),
                    PublishedAtXPath = "//meta[@name='mediator_published_time']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("56366b43-4d17-44a6-9bdd-1cb63ec7dcfb"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("84cb0a27-b2ef-4cd4-93d2-fcb0fdecf1d0"),
                NewsSiteUrl = "https://russian.rt.com/",
                NewsUrlXPath = "//a[contains(@class, 'link') and contains(@href, 'news/')]/@href"
            };
        }
    }
}
