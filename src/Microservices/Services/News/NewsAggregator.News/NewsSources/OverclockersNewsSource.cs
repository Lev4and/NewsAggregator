using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class OverclockersNewsSource : NewsSource
    {
        public OverclockersNewsSource()
        {
            Id = Guid.Parse("dac8cec6-c84d-4287-b0b9-71f4cf304c7e");
            Title = "Overclockers";
            SiteUrl = "https://overclockers.ru/";
            IsEnabled = true;
            IsSystem = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("955eb645-e135-46d6-990e-1348bcc962d8"),
                Small = "https://overclockers.ru/assets/apple-touch-icon.png",
                Original = "https://overclockers.ru/assets/apple-touch-icon-120x120.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("4d30d497-e95e-428f-b8ed-b38f67a62894"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("c5e74bb8-c08b-4498-baad-11ce59564015"),
                    Tag = new ComputerHardwareNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("613dbfcf-7f5c-4060-a92a-d2ec7586f4a3"),
                TitleXPath = "//a[@class='header']/text()",
                HtmlDescriptionXPath = "//div[contains(@class, 'material-content')]/*",
                TextDescriptionXPath = "//div[contains(@class, 'material-content')]/p//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("c694b06f-3d99-4ec4-b939-374b524b728f"),
                    TitleXPath = "//meta[@name='description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("73e2d740-d23b-44d5-b0a4-634da72f0daf"),
                    NameXPath = "//span[@class='author']/a/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("da259816-c238-4a5e-af4b-be606546572f"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("8208ff9e-fbf8-4206-b4d8-e7f7287b2dec"),
                    PublishedAtXPath = "//span[@class='date']/time/@datetime",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("677d695e-ddcc-4a66-aa7f-ff1ccdb726dd"),
                            Format = "yyyy-MM-dd HH:mm"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("773dc871-3e67-4375-9ded-71969f1e0a81"),
                NewsUrlXPath = "//div[contains(@class, 'event')]//a[not(contains(@href, '#comments'))]/@href",
                NewsSiteUrl = "https://overclockers.ru/news"
            };
        }
    }
}
