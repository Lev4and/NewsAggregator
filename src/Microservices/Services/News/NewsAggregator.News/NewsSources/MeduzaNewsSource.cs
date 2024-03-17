using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class MeduzaNewsSource : NewsSource
    {
        public MeduzaNewsSource()
        {
            Id = Guid.Parse("3a346f18-1781-408b-bc8d-2f8e4cbc64ea");
            Title = "Meduza";
            SiteUrl = "https://meduza.io/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("6e7dee47-3b1c-4ec8-b2c7-b6ec29fcc6f5"),
                Small = "https://meduza.io/favicon-32x32.png",
                Original = "https://meduza.io/apple-touch-icon-180.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("b681073b-3a8a-469e-8d03-db44364f0557"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("eeb9e776-c05e-499f-ad3d-49dd23a8f1e1"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("2765ef2f-338c-4f92-a1d2-4ed1dc54ed83"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("6a7db6d7-c4ec-471c-93e2-9f7b9dd9180c"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='GeneralMaterial-module-article']/*[position()>1]",
                TextDescriptionXPath = "//div[@class='GeneralMaterial-module-article']/*[position()>1]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("4ff736eb-a44a-4880-aa4f-f70988527bfe"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("8f7062f8-e5f9-429b-900f-98412ea04f84"),
                    NameXPath = "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_hasSource') and not(time)]/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("d8dc9296-e936-406b-aad9-916f05f1b3fe"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("5e7874b1-13e9-4cf5-a96a-6612fe3661cf"),
                    PublishedAtXPath = "//div[@class='GeneralMaterial-module-materialHeader']//div[contains(@class, 'MetaItem-module_datetime')]/time/text()",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "UTC",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("a9340a6d-ec66-49fc-8150-3a6a698e999e"),
                            Format = "HH:mm, d MMMM yyyy"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("04980ca4-2525-446d-ba36-b6ec342d951e"),
                NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                NewsSiteUrl = "https://meduza.io/"
            };
        }
    }
}
