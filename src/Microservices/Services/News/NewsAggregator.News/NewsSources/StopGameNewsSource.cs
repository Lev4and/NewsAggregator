using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class StopGameNewsSource : NewsSource
    {
        public StopGameNewsSource()
        {
            Id = Guid.Parse("b5594347-6ec0-44c0-b381-7ae47f04fa56");
            Title = "StopGame";
            SiteUrl = "https://stopgame.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("495799aa-0817-433e-9abe-5481c0f3d569"),
                Small = "https://stopgame.ru/favicon.ico",
                Original = "https://stopgame.ru/favicon_512.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("39b9de90-e868-41c1-8390-632d344850d7"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("853e103e-0105-46c0-869b-3b7c3ed19a46"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.VideoGamesNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("be3e061e-25f4-4b43-a9f6-45db165b6000"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*",
                TextDescriptionXPath = "//section[contains(@class, '_page-section')]/div[contains(@class, '_content_')]/*[contains(@class, '_text_')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("568f8fd4-3715-4895-a979-509ce2da11e2"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false,
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("118e708c-8b15-496c-bffd-1f30c5679ba8"),
                    NameXPath = "//section[contains(@class, '_page-section')]//div[contains(@class, '_bottom-info_')]//span[contains(@class, '_user-info__name_')]/text()",
                    IsRequired = false,
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("bf4cfe59-066b-4d7c-ab2c-ca2690648826"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false,
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("cea22ad0-6634-4def-9b5b-f1e754ce2d8d"),
                NewsUrlXPath = "//div[contains(@class, 'list-view')]//div[contains(@class, '_card')]/a/@href",
                NewsSiteUrl = "https://stopgame.ru/news"
            };
        }
    }
}
