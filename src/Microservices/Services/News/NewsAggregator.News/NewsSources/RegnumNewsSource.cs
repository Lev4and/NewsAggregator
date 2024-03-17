using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class RegnumNewsSource : NewsSource
    {
        public RegnumNewsSource()
        {
            Id = Guid.Parse("60747323-2a4c-44e1-880d-7e5e36642645");
            Title = "ИА REGNUM";
            SiteUrl = "https://regnum.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("a786f93c-3c1d-4561-a699-58fba081cc37"),
                Small = "https://regnum.ru/favicons/favicon-32x32.png?v=202305",
                Original = "https://regnum.ru/favicons/apple-touch-icon.png?v=202305"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("53a0fa14-82ed-49a0-9f6c-0ad21e2c8ff8"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("2134a235-9b9d-4010-b627-2de04e044a0f"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("70b71eaf-20ce-489e-bf24-77201fb2a506"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("14db83c2-cee9-47a2-b8fc-210bbbd399aa"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]",
                TextDescriptionXPath = "//div[@class='article-text']/*[not(name()='div' and @class='picture-wrapper')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("4b514907-cb5c-4b5c-aaa9-1d581955c40b"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("e9c5bd35-588d-49c8-b0d0-3eda43d0afea"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("505e7e1d-72a9-4f64-b2ab-faf55410329f"),
                NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                NewsSiteUrl = "https://regnum.ru/news"
            };
        }
    }
}
