using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class SmartLabNewsSource : NewsSource
    {
        public SmartLabNewsSource()
        {
            Id = Guid.Parse("65141fc2-760f-4866-86c5-08cc764cabac");
            Title = "SMART-LAB";
            SiteUrl = "https://smart-lab.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("6b5da5aa-29f4-4ee9-a310-db70936a1ff1"),
                Small = "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico",
                Original = "https://smart-lab.ru/templates/skin/smart-lab-x3/images/favicon.ico"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("6a63cd8b-9bfd-4c7b-9fc4-add3af28ab09"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("afed64e4-db23-4f41-9519-6570621c0b30"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("e86d098a-4561-40b9-83e0-d35612ecfafe"),
                    Tag = new EconomyNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("985748c8-d5a4-48c5-a41b-b23c8726d297"),
                    Tag = new FinanceNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("289bab5a-8dd4-4ca7-a510-ff6a496b3993"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']/*",
                TextDescriptionXPath = "//div[@id='content']//div[contains(@class, 'topic')]/div[@class='content']//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("a33df3a5-b0b4-4c61-8978-67452ed955c9"),
                    TitleXPath = "//meta[@name='DESCRIPTION']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("c89266cc-1f5c-4839-8b7c-e86ba789c36d"),
                    NameXPath = "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='author']//text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("2b7405f0-8db7-447b-a239-4b8454cba04b"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("22c82c40-fe3a-4394-ab34-295e3c094dcf"),
                    PublishedAtXPath = "//div[@id='content']//div[contains(@class, 'topic')]/ul[contains(@class, 'blog_more')]//li[@class='date']/text()",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("664d9377-1900-4561-aa21-c2b0a7a1f8ac"),
                            Format = "dd MMMM yyyy, HH:mm"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("e33af74d-60d3-4b07-8a1f-f35dd3a2965a"),
                NewsUrlXPath = "//a[not(@href='/blog/') and starts-with(@href, '/blog/') and contains(@href, '.php')]/@href",
                NewsSiteUrl = "https://smart-lab.ru/news/"
            };
        }
    }
}
