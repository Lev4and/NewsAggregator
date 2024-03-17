using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class InterfaxNewsSource : NewsSource
    {
        public InterfaxNewsSource() 
        {
            Id = Guid.Parse("57597b92-2b9d-422e-b0a7-9b11326c879b");
            Title = "Интерфакс";
            SiteUrl = "https://www.interfax.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("db46c593-155d-4775-b999-dbe4eb772fb1"),
                Small = "https://www.interfax.ru/touch-icon-iphone.png",
                Original = "https://www.interfax.ru/touch-icon-ipad-retina.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("f60c2ec2-8e72-462f-8144-987d9ba37751"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("ad8b55a9-c949-469f-956a-5624ecb7f577"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("dc2ed602-baa8-4a9e-8f38-b1cf40d5bb59"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("5c2d9dff-16d7-47f9-8d32-07f8fb52ac76"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]",
                TextDescriptionXPath = "//article[@itemprop='articleBody']/*[not(name() = 'h1') and not(name() = 'aside') and not(name() = 'meta') and not(name() = 'link') and not(@itemprop)]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("552e2547-f0f4-4536-ac2b-0368eb0d03c6"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("515be790-404d-48ca-8d97-642a505b2149"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("e762bdb6-dfae-410b-9478-3ff4b45dbe70"),
                    PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("3d3f9878-e5a6-4163-acb9-afe1346b3cf2"),
                            Format = "yyyy-MM-ddTHH:mm:ss"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("b8626e48-242d-48e4-aa30-8ca2936a0d59"),
                    ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("10a053d0-a81c-42a6-a032-1a217bc6e9c1"),
                            Format = "yyyy-MM-ddTHH:mm:ss"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("cf99e4fc-dbe3-4be7-9f98-1eccfc954f39"),
                NewsSiteUrl = "https://www.interfax.ru/",
                NewsUrlXPath = "//div[@class='timeline']//a[@tabindex=5]/@href"
            };
        }
    }
}
