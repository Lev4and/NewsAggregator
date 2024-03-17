using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class PravdaRuNewsSource : NewsSource
    {
        public PravdaRuNewsSource()
        {
            Id = Guid.Parse("13f235b7-a6f6-4da4-83a1-13b5af26700a");
            Title = "Правда.ру";
            SiteUrl = "https://www.pravda.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("52827f36-597f-424c-bc69-6e71f2bdde5c"),
                Small = "https://www.pravda.ru/favicon.ico",
                Original = "https://www.pravda.ru/pix/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("311ea1df-f338-4d3a-83f9-9f69c9fb5593"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("e33ba004-f85b-4714-a381-ee25fafd52f0"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("99d1cd54-f21d-407d-b1e1-54a6bd79f6ab"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("aed24362-5c8e-4b31-9bbe-bb068f9c0f01"),
                TitleXPath = "//meta[@name='title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]",
                TextDescriptionXPath = "//div[contains(@class, 'full-article')]/*[not(name()='h1') and not(name()='style') and not(name()='div')]//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("20786554-85aa-42a5-80f3-953dccb09f55"),
                    NameXPath = "//meta[@name='author']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("48dd42bd-47ea-4a97-aeff-bb84db84e6b2"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("c4d81a5f-b716-4dec-9ddf-3c908343be6a"),
                    TitleXPath = "//meta[@name='description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("a2c411a5-4b6a-4ed8-b383-b1a4f05b4605"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("94e51912-995a-4976-a4a0-4cc03ffe4e82"),
                            Format = "yyyy-MM-ddTHH:mm:ssZ"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("91c40a45-f102-46d4-bd9b-4e11869f18cd"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("4601b17e-822b-4b19-862c-a0a6c5b7a23c"),
                            Format = "yyyy-MM-ddTHH:mm:ssZ"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("99d95b1b-1ecf-42ec-8e95-e4dcc217762d"),
                NewsSiteUrl = "https://www.pravda.ru/",
                NewsUrlXPath = "//a[contains(@href, '/news/') and not(@href='https://www.pravda.ru/news/')]/@href"
            };
        }
    }
}
