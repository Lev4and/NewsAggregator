using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class _3DNewsNewsSource : NewsSource
    {
        public _3DNewsNewsSource()
        {
            Id = Guid.Parse("5aebacd6-b4d5-4839-b2f0-533ff3329941");
            Title = "3Dnews.ru";
            SiteUrl = "https://3dnews.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("d1418d56-a990-448a-8334-a8cc8cec1b00"),
                Small = "https://3dnews.ru/assets/3dnews_logo_color.png",
                Original = "https://3dnews.ru/assets/images/3dnews_logo_soc.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("d6846cf7-bca1-48d3-b78d-188d94e2f80a"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("b6d1bfd8-38e9-4365-936d-ed3c6c09b357"),
                    Tag = new InformationTechnologiesNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("c8f40af2-f3b9-40de-ab83-dd5e74962bfb"),
                    Tag = new TechnologiesNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("4762d902-fdfe-413d-9c8d-76e619e81c7d"),
                    Tag = new ComputerHardwareNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("44d47f91-a811-4cc3-a70f-f12236d1476d"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4]",
                TextDescriptionXPath = "//div[contains(@class, 'article-entry')]//div[@class='js-mediator-article']/*[position()>4 and not(name()='script')]//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("a5a0d928-4db3-49a7-8a52-2ba8d93fd651"),
                    NameXPath = "//meta[@name='mediator_author']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("09f7efa7-635a-4a7b-9e00-dbee344eaf0a"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("4a01f0ed-4373-4b4c-be4c-5d8b23cd7b4b"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("82ed5673-25e2-497f-aaea-3dd42ecd4f85"),
                    PublishedAtXPath = "//div[contains(@class, 'article-entry')]//div[@class='entry-info']/span[@itemprop='datePublished']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("04d00724-05cc-4ca5-a951-889b75da6f97"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("0896d6d1-cbe7-4103-a47e-d9be4ad3c550"),
                NewsSiteUrl = "https://3dnews.ru/news/",
                NewsUrlXPath = "//div[@class='news-feed-all']//a[@class='entry-header']/h1/../@href"
            };
        }
    }
}
