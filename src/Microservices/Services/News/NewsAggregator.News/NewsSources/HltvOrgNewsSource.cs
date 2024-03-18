using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class HltvOrgNewsSource : NewsSource
    {
        public HltvOrgNewsSource()
        {
            Id = Guid.Parse("e4b3e286-3589-49de-892b-d0d06e719115");
            Title = "HLTV.org";
            SiteUrl = "https://www.hltv.org/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("5195571a-9041-4d0e-a9d1-dddbc5c9cb39"),
                Small = "https://www.hltv.org/img/static/favicon/favicon-32x32.png",
                Original = "https://www.hltv.org/img/static/favicon/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("508b2fd4-609d-4ce2-925a-a18c7b9889db"),
                    Tag = new EnglishNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("1bc5683b-b0fa-4a72-b9d8-bfc9c45360c6"),
                    Tag = new CounterStrikeNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("6ce3a3ff-775d-4606-a3eb-462daa663500"),
                    Tag = new CybersportNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("d6550af5-7e26-49cc-b9bb-65ddfe9ccd67"),
                    Tag = new SportNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("f63d1e4f-e82d-4020-8b9c-65beaab1d7c3"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//article//div[@class='newstext-con']/*[position()>2]",
                TextDescriptionXPath = "//article//div[@class='newstext-con']/*[position()>2]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("15009b74-1ebf-4de7-b127-24e412d887b1"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("7d69c14b-403d-4216-ac58-f66c87bee0c8"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseVideoSettings = new NewsParseVideoSettings
                {
                    Id = Guid.Parse("b5ff5316-a5a2-44b7-855f-7af3788ab3e9"),
                    UrlXPath = "//article//div[@class='videoWrapper' and @itemprop='video']/iframe[@class='video']/@src",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("7a85f179-0e73-4d6e-9792-5d93a47e0484"),
                    NameXPath = "//article//span[@class='author']/a[@class='authorName']/span/text()",
                    IsRequired = false,
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("5c23cab5-7864-429b-9080-ba88f81c6751"),
                    PublishedAtXPath = "//article//div[@class='article-info']/div[@class='date']/text()",
                    PublishedAtCultureInfo = CultureInfoConstants.EnglishUsaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.CentralEuropeStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("055ce086-a067-43f4-98ad-4b3b039328d6"),
                            Format = "d-M-yyyy HH:mm"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("01116c2c-7bf6-496d-96f6-9d10d4b14e97"),
                NewsUrlXPath = "//a[contains(@href, '/news/')]/@href",
                NewsSiteUrl = "https://www.hltv.org/",
            };
        }
    }
}
