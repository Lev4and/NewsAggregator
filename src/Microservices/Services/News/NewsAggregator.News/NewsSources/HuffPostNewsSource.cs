using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class HuffPostNewsSource : NewsSource
    {
        public HuffPostNewsSource()
        {
            Id = Guid.Parse("1f913a9a-4e5a-4925-89c1-51e985f63e9d");
            Title = "HuffPost";
            SiteUrl = "https://www.huffpost.com/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("aaf79c06-980f-4d3c-9d89-0281ccfecc70"),
                Small = "https://www.huffpost.com/favicon.ico",
                Original = "https://www.huffpost.com/favicon.ico"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("35a38041-59d7-4924-ad4a-92ac14988e54"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.EnglishNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("9f4fd158-51d1-4aa9-ad41-0d59d26ac38f"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.UsaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("371d2b27-1b5f-4f87-bb12-3e3b11651b44"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("32b2600c-03b7-4d2d-ace8-77b11e1a5041"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//section[contains(@class, 'entry__content-list js-entry-content')]/*[not(contains(@class, 'cli-embed--header-media')) and not(contains(@class, 'cli-support-huffpost'))]",
                TextDescriptionXPath = "//section[contains(@class, 'entry__content-list js-entry-content')]/*[not(contains(@class, 'cli-embed--header-media')) and not(contains(@class, 'cli-support-huffpost'))]/p//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("82bb1ac2-5fbb-4240-bca2-5417604ec562"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("10957082-a831-4ffb-86e1-379efef08111"),
                    NameXPath = "//header//div[contains(@class, 'bottom-header')]//div[contains(@class, 'author-list')]//a[contains(@class, 'headshot__link') and @data-vars-subunit-name='author']/@data-vars-item-name",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("8c523334-f94b-4c87-ae3d-a6d749bc29b9"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("74a87f1a-0325-4690-8c87-8ba4d24e078b"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = "en-US",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("a77f62ce-bb2c-41a7-8a35-f0aa8147e4de"),
                            Format = "yyyy-MM-ddTHH:mm:ssZ"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("50257fdd-fcc6-4a8e-822c-4834d0f1d762"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = "en-US",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("db537dea-c0ab-426c-a394-10231d9c8a29"),
                            Format = "yyyy-MM-ddTHH:mm:ssZ"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("d54003f4-dab6-4218-a59d-7374ded91cce"),
                NewsUrlXPath = "//a[contains(@href, '/entry/')]/@href",
                NewsSiteUrl = "https://www.huffpost.com/"
            };
        }
    }
}
