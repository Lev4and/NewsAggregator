using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class Moscow24NewsSource : NewsSource
    {
        public Moscow24NewsSource()
        {
            Id = Guid.Parse("3e24ec11-86a4-4db8-9337-35a00988da7d");
            Title = "Москва 24";
            SiteUrl = "https://www.m24.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("7e056d72-a4a4-4608-b393-b56d976a2bad"),
                Small = "https://www.m24.ru/img/fav/favicon-32x32.png",
                Original = "https://www.m24.ru/img/fav/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("06b2c915-82cf-4115-a537-cbc91d80783a"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("e3566a06-d006-4937-9bb5-90eade9d2bac"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("8949a721-7dfc-428c-a03d-6721e5b35879"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.MoscowNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("f6ef6598-401b-4cd8-8654-f3009b41593f"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]",
                TextDescriptionXPath = "//div[@class='b-material-body']/div/*[not(@class='b-material-incut-m-image')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("8cb13ca5-b19a-47dd-93f4-13f82a2afaab"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false,
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("7e8d5e93-0edd-4054-8d1b-86b738bca16b"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseVideoSettings = new NewsParseVideoSettings
                {
                    Id = Guid.Parse("f0a8b4c3-22d5-4aa7-be0c-0250cfa04d53"),
                    UrlXPath = "//meta[@property='og:video:url']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("4a6be1f2-8429-4185-a9c6-03aeda076dcd"),
                    PublishedAtXPath = "//p[@class='b-material__date']/text()",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("b871e83e-0792-470a-8610-4264a83c16b1"),
                            Format = "dd MMMM yyyy, HH:mm"
                        },
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("6c0231f6-71e1-4911-959c-9c93c1408781"),
                            Format = "dd MMMM, HH:mm"
                        },
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("7b5a7ff9-dc44-4399-8049-30505337726e"),
                            Format = "HH:mm"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("6d057994-d84f-4437-a8bc-bd4e427493ca"),
                NewsSiteUrl = "https://www.m24.ru/",
                NewsUrlXPath = "//a[contains(@href, '/news/')]/@href"
            };
        }
    }
}
