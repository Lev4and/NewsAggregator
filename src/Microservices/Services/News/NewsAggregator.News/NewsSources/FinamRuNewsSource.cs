using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class FinamRuNewsSource : NewsSource
    {
        public FinamRuNewsSource()
        {
            Id = Guid.Parse("9e3453b3-be81-4f3b-93da-45192677c6a9");
            Title = "Финам.Ру";
            SiteUrl = "https://www.finam.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("9e7d94a1-3960-4019-aa85-e4f384ec14ea"),
                Small = "https://www.finam.ru/favicon.png",
                Original = "https://www.finam.ru/favicon-144x144.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("9d0a0cea-e52f-4418-8652-3a152788a1ff"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("a0d39b98-3a62-4153-9a5f-b678bd754ff0"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("53d62165-056b-4061-9415-696925c16912"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.EconomyNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("4ef14b7a-d41d-4eab-b58d-db7ce19bcdbb"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.FinanceNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("6d16ec92-860e-4bd8-9618-1e5b2ac5a792"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]/*",
                TextDescriptionXPath = "//div[contains(@class, 'finfin-local-plugin-publication-item-item-')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("688c8958-8946-4e0c-a943-3a614eedf013"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("0f7f9888-b12e-48cc-931c-8380d9e8e7e4"),
                    NameXPath = "//meta[@property='article:author']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("6d23a40c-508d-4914-9c4e-4ca0e9db1985"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("80bc5b20-336c-4ac1-9ee0-e231d0ef74c7"),
                    PublishedAtXPath = "//span[@id='publication-date']/text()",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("be418012-872b-49b6-bce4-f91a9bf8ef1d"),
                            Format = "dd.MM.yyyy HH:mm"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("8325b474-7ad4-40bc-a721-82cf3f01d4c2"),
                NewsUrlXPath = "//a[starts-with(@href, 'publications/item/') or starts-with(@href, '/publications/item/')]/@href",
                NewsSiteUrl = "https://www.finam.ru/"
            };
        }
    }
}
