using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class StarHitNewsSource : NewsSource
    {
        public StarHitNewsSource()
        {
            Id = Guid.Parse("05765a1b-b174-4ad1-9f63-3189a52303f9");
            Title = "Сетевое издание «Онлайн журнал StarHit (СтарХит)";
            SiteUrl = "https://www.starhit.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("5f715b2b-8509-4425-aaed-2da285f295d0"),
                Small = "https://cdn.hsmedia.ru/public/favicon/starhit/favicon.png",
                Original = "https://cdn.hsmedia.ru/public/favicon/starhit/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("4ee63615-d18c-4f48-8b9a-8aff52d12006"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("50d237f6-59fa-44bc-96f4-344bab93f074"),
                    Tag = new ShowBusinessNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("49c1bb0c-b546-4142-a7ba-4925f71a933c"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]",
                TextDescriptionXPath = "//section[@itemprop='articleBody']/div[@class='ds-article-content-block-and-creative-container' and position()>1]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("e3d307d2-0cd5-42d2-9c7c-2fab779bb299"),
                    TitleXPath = "//p[contains(@itemprop, 'alternativeHeadline')]/text()",
                    IsRequired = false,
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("dd3601cc-4a2c-480f-9860-9f5183d8c67a"),
                    NameXPath = "//meta[@name='author']/@content",
                    IsRequired = false,
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("1927aaba-9fb9-4caf-a3f6-1586a082e21a"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false,
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("e6bd53e0-c868-451c-87a5-e048343b2759"),
                    PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("95c6753e-1df4-4708-9b80-6976c6b91292"),
                            Format = "yyyy-MM-ddTHH:mm:ssZ"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("348a6cf9-f469-4f19-a12c-bdc3f525947c"),
                    ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                    ModifiedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("9baa0874-10a0-4e13-8fc9-fb95036b8958"),
                            Format = "yyyy-MM-ddTHH:mm:ssZ"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("3dd178c2-7dd6-4f7d-9fa3-8aad161b000a"),
                NewsUrlXPath = "//a[@class='announce-inline-tile__label-container']/@href",
                NewsSiteUrl = "https://www.starhit.ru/novosti/"
            };
        }
    }
}
