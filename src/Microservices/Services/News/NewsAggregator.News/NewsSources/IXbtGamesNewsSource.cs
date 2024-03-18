using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class IXbtGamesNewsSource : NewsSource
    {
        public IXbtGamesNewsSource()
        {
            Id = Guid.Parse("604e9548-9b99-4bd4-ab90-4bf90b4a1807");
            Title = "iXBT.games";
            SiteUrl = "https://ixbt.games/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("def8f81b-0a9b-44fb-a6bc-26f398fb175c"),
                Small = "https://ixbt.games/images/favicon/gt/apple-touch-icon.png",
                Original = "https://ixbt.games/images/favicon/gt/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("7afa8562-f5b4-4cdf-92c0-af0594d4be4d"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("ce7a5f4b-071f-4c3e-af81-758a1b918c39"),
                    Tag = new VideoGamesNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("f1b027fc-2809-4eaa-9858-c49a8756852f"),
                TitleXPath = "//meta[@name='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]",
                TextDescriptionXPath = "//div[contains(@class, 'container-fluid shifted') and not(p[@class='announce lead']) and not(h1) and not(hr)]//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("325ee59a-478b-4ea2-991b-06c65c269bbe"),
                    NameXPath = "//div[@class='container-fluid publication-footer']//a[contains(@class, 'text-secondary')]/@title",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("140c9334-8e52-4c07-a0a2-f4842820af31"),
                    UrlXPath = "//meta[@name='og:image']/@content",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("1f572948-8062-4f2a-9603-54fd0815ff44"),
                    TitleXPath = "//meta[@name='og:description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("2622b86a-c47b-4143-a11e-f2aad18faa8e"),
                    PublishedAtXPath = "//div[contains(@class, 'pubdatetime')]//div[contains(@class, 'badge-time')]//text()",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = false,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("04fe3029-59e0-4670-9a51-99593a0f8041"),
                            Format = "yyyy-MM-dd HH:mm:ss"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("52805bca-3e28-413b-8da3-77c9411f6ae1"),
                NewsSiteUrl = "https://ixbt.games/news/",
                NewsUrlXPath = "//a[@class='card-link']/@href"
            };
        }
    }
}
