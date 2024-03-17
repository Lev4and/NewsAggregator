using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class VzglyadNewsSource : NewsSource
    {
        public VzglyadNewsSource()
        {
            Id = Guid.Parse("e2ce0a01-9d10-4133-a989-618739aa3854");
            Title = "ВЗГЛЯД.РУ";
            SiteUrl = "https://vz.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("f22a5c00-53d0-43b8-93a3-1cdac2e103cc"),
                Small = "https://vz.ru/static/images/favicon.ico",
                Original = "https://vz.ru/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("0b19d00f-4483-4f55-818a-a7b34925b37b"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("4f514879-ca5a-45a2-9c9c-4834f7f98bd7"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("b12ca17b-650c-4fbb-84a3-10057f365551"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("a1b03754-30d4-4c65-946d-10995830a159"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//article/div[@class='news_text']",
                TextDescriptionXPath = "//article/div[@class='news_text']//text()",
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("86d081ed-0909-49c3-98fe-324f17415c27"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("4087fb58-d428-4c26-b88d-b20e5715a6f8"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("c8b007a9-e3db-4231-9a5f-5aa3f103e49a"),
                    NameXPath = "//article/p[@class='author']/text()",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("f02b9ed4-7b5b-4572-bf74-604513ced86b"),
                    PublishedAtXPath = "//article/div[@class='header']/span/text()",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("8e6578d8-62d7-4761-a9a2-60e8cfd4da58"),
                            Format = "d MMMM yyyy, HH:mm\" •\""
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("3b9ca981-bc22-40e2-93be-e08c99369c45"),
                NewsSiteUrl = "https://vz.ru/",
                NewsUrlXPath = "//a[contains(@href, '.html') and not(contains(@href, '#comments')) and not(contains(@href, '?')) and not(contains(@href, '/about/'))]/@href"
            };
        }
    }
}
