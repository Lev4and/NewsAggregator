using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class BeltaNewsSource : NewsSource
    {
        public BeltaNewsSource()
        {
            Id = Guid.Parse("fc0a229f-bde4-4f61-b4eb-75d1285665dd");
            Title = "БелТА";
            SiteUrl = "http://www.belta.by/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("4975ba0c-d5eb-44cf-8743-2aa7d621c5d1"),
                Small = "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg",
                Original = "https://www.belta.by/images/storage/banners/000016_a133e848cb2e7b1debb7102d19e4d139_work.svg"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("9bed47b1-ba64-453a-91df-0c08b9ab61c1"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("393c3856-dbc5-4620-9a35-635894691dfc"),
                    Tag = new BelarusNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("2565182d-475e-4217-8b8d-b2ba9dbeb092"),
                    Tag = new PoliticsNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("77a6c5a1-b883-444f-ba7e-f0289943947f"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='js-mediator-article']",
                TextDescriptionXPath = "//div[@class='js-mediator-article']//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("48759786-80ce-4ea1-84c2-f5cbb3b3e9d9"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("e8ae178c-a3c7-4ec4-8af8-d1431ef0b1a5"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("20903a2a-fdf2-4909-8478-bbfd57c492be"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("c0ff192d-ad34-459b-8fe8-49d20e6c5f41"),
                            Format = "yyyy-MM-dd HH:mm:ss"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("62afc18d-a34f-4989-8c4c-2a5d7deabf6b"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    ModifiedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("9ac871c4-a009-4f03-8920-3166aa64deeb"),
                            Format = "yyyy-MM-dd HH:mm:ss"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("d9c7c3b0-bdc7-4bcc-afec-9423cb451086"),
                NewsSiteUrl = "http://www.belta.by/",
                NewsUrlXPath = "//a[contains(@href, 'www.belta.by') and contains(@href, '/view/')]/@href"
            };
        }
    }
}
