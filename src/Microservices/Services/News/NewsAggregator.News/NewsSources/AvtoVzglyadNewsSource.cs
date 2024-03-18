using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class AvtoVzglyadNewsSource : NewsSource
    {
        public AvtoVzglyadNewsSource()
        {
            Id = Guid.Parse("454f4f08-58cf-4ab7-9012-1e5ba663570c");
            Title = "АвтоВзгляд";
            SiteUrl = "https://www.avtovzglyad.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("ef6108bf-e9c1-4f8b-b4f7-7e933b1c7ac3"),
                Small = "https://www.avtovzglyad.ru/static/images/favicon/favicon-32x32.png",
                Original = "https://www.avtovzglyad.ru/static/images/favicon/safari-pinned-tab.svg"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("f603da29-65c5-4713-80bd-ec8023b9c94d"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("a5c23469-5399-4848-bf82-14e195c357ac"),
                    Tag = new AutoNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("e3fcdd00-2152-4d84-8f8c-bf70e4996990"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//section[@itemprop='articleBody']/*",
                TextDescriptionXPath = "//section[@itemprop='articleBody']/*[not(name()='script')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("999110e1-29e6-4a98-8361-743dd7f8bf07"),
                    TitleXPath = "//meta[@name='description']/@content",
                    IsRequired = false,
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("4b846398-fc4c-4c1f-adac-2bc61fea6752"),
                    NameXPath = "//div[@class='preview__author-block']//div[@class='author__about']/a[@itemprop='name']/@content",
                    IsRequired = false,
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("1f4694bc-c0d7-405c-ae73-88053c0ebc14"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false,
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("c6115996-838b-4309-813e-d520085af7df"),
                    PublishedAtXPath = "//div[@class='article-details']/span[@class='article-details__time']/time/@datetime",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("9c7e361a-0096-483d-8f8a-edae7e347e1a"),
                            Format = "d MMMM yyyy"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("a169d814-b17e-4062-a2b5-1599ede6783c"),
                NewsUrlXPath = "//a[@class='news-card__link']/@href",
                NewsSiteUrl = "https://www.avtovzglyad.ru/news/"
            };
        }
    }
}
