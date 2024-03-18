using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class ChampionatNewsSource : NewsSource
    {
        public ChampionatNewsSource()
        {
            Id = Guid.Parse("49bcf6b7-15bc-4f30-a3d6-3c88837aa039");
            Title = "Чемпионат.com";
            SiteUrl = "https://www.championat.com/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("3fbe2b42-7817-422b-a3e1-020942b42d4b"),
                Small = "https://st.championat.com/i/favicon/favicon-32x32.png",
                Original = "https://st.championat.com/i/favicon/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("5ec2412d-81f3-4157-924d-44ad65e0a24a"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("4998ee1a-d54c-4d29-be1d-8df7c60ee7b3"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("1a3984fc-b3b1-4d9f-bdff-716636bb2353"),
                    Tag = new SportNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("052241f9-e3e7-4722-9f56-7202de4a331e"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//article/div[@class='article-content']/*[not(@class)]",
                TextDescriptionXPath = "//article/div[@class='article-content']/*[not(@class)]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("86d2ce89-f28a-4779-be9c-1832701f99d4"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("4664ca50-bfde-4200-a8eb-af35872e79dd"),
                    NameXPath = "//meta[@property='article:author']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("2e408438-34d0-4ec7-9183-f14c49c50ad6"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("a5685486-3a98-45aa-96b7-d25cd5e40c5d"),
                    PublishedAtXPath = "//article//header//time[@class='article-head__date']/text()",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("a3e3e93d-5850-4f27-885b-d80d10d72a8e"),
                            Format = "d MMMM yyyy, HH:mm \"МСК\""
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("e69f2b5a-89e8-43df-aa5d-ca4139af6f95"),
                NewsSiteUrl = "https://www.championat.com/news/1.html?utm_source=button&utm_medium=news",
                NewsUrlXPath = "//a[contains(@href, 'news-') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href"
            };
        }
    }
}
