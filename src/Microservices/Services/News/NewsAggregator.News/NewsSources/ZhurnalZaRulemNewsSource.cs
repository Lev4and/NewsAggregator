using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class ZhurnalZaRulemNewsSource : NewsSource
    {
        public ZhurnalZaRulemNewsSource()
        {
            Id = Guid.Parse("a71c23bf-67e9-4955-bc8e-6226bd86ba90");
            Title = "Журнал \"За рулем\"";
            SiteUrl = "https://www.zr.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("7083afb5-2799-44f7-a508-60369598da29"),
                Small = "https://www.zr.ru/favicons/favicon.ico",
                Original = "https://www.zr.ru/favicons/safari-pinned-tab.svg",
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("942b3d98-af39-40f6-a2d4-e4acb4d48df2"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("050c5ae6-0a40-40fc-b900-4e16ec28159c"),
                    Tag = new AutoNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("2d46f779-c13c-4699-9460-629e254a6444"),
                TitleXPath = "//meta[@name='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]",
                TextDescriptionXPath = "//div[contains(@class, 'styled__StoryBody')]/*[not(name()='p' and contains(@class, 'styled__StoryParagraph') and position()=1) and not(name()='div' and contains(@class, 'styled__StoryImgContainer') and position()=2)]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("e250183d-d316-4ef3-b7cf-887ce77ac342"),
                    TitleXPath = "//div[contains(@class, 'styled__StoryBody')]/p[contains(@class, 'styled__StoryParagraph') and position()=1]/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("679b3f84-a212-422b-a41d-3544ae6c997a"),
                    UrlXPath = "//meta[@name='og:image']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("6ef19113-6578-47ed-93c8-b2b61cd13d08"),
                    NameXPath = "//div[contains(@class, 'styled__StoryInfoAuthors')]/div[contains(@class, 'styled__InfoAuthor')]//span[contains(@class, 'styled__AuthorName')]/text()",
                    IsRequired = false,
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("1b2f8ada-c349-4930-98ed-896d0b89093c"),
                NewsUrlXPath = "//a[contains(@href, '/news/') and not(starts-with(@href, '/news/')) and not(starts-with(@href, 'https://'))]/@href",
                NewsSiteUrl = "https://www.zr.ru/news/"
            };
        }
    }
}
