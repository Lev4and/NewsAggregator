using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class SportsRuNewsSource : NewsSource
    {
        public SportsRuNewsSource()
        {
            Id = Guid.Parse("3e1f065a-c135-4429-941e-d870886b4147");
            Title = "Sports.ru";
            SiteUrl = "https://www.sports.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("5531cc3d-cee5-490a-aaac-20b826e1135b"),
                Small = "https://www.sports.ru/apple-touch-icon-76.png",
                Original = "https://www.sports.ru/apple-touch-icon-1024.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("b2a8ec2b-61da-45fd-b98f-6b32d0ccf331"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("c3fc77db-1764-4453-a6e9-6f85ef5fde66"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("0ac9ad4a-29b6-4689-aadc-b3b75a3b034c"),
                    Tag = new SportNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("8c399ef5-9d29-4442-a621-52867b8e7f6d"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'news-item__content')]",
                TextDescriptionXPath = "//div[contains(@class, 'news-item__content')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("30955c5b-0b5c-4655-9581-4972b4fc0df5"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("1119d2b6-db6a-4750-8263-9fb0025cc536"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("02333a48-69aa-4492-a33f-3ac9324d3970"),
                    NameXPath = "//footer[@class='news-item__footer']/div[@class='news-item__footer-after-news']/p[position()=1]//span/text()",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("dc0d0ef7-eb9e-4632-b75e-9d7d9ba44daa"),
                    PublishedAtXPath = "//header[@class='news-item__header']//time/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("a614d044-0c1d-4a5a-b547-a22ec2fdd1c0"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("d292849b-0727-4311-b0ff-da147c4d344a"),
                NewsSiteUrl = "https://www.sports.ru/news/",
                NewsUrlXPath = "//a[contains(@href, '.html') and not(contains(@href, '.html#comments')) and not (contains(@href, '/blogs/'))]/@href"
            };
        }
    }
}
