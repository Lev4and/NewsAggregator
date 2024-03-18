using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class RenTvNewsSource : NewsSource
    {
        public RenTvNewsSource()
        {
            Id = Guid.Parse("c169d8ad-a9fe-44e9-af6a-fd337ae10000");
            Title = "РЕН ТВ";
            SiteUrl = "https://ren.tv/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("504e7035-e6bb-434a-939c-5b4515ad4e48"),
                Small = "https://ren.tv/favicon-32x32.png",
                Original = "https://ren.tv/apple-touch-icon.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("30042a38-0f29-4378-b9e9-12c64a043913"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("3073fa94-5ff5-411f-b8b7-25663045c4da"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("8512f634-1ddd-405a-841d-45545534904f"),
                    Tag = new PoliticsNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("6159dd07-94f5-471e-b6ea-0cd73b2de872"),
                    Tag = new TVNewsTag()
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("cba88caa-d8af-4e40-b8fa-14946187e939"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='widgets__item__text__inside']/*",
                TextDescriptionXPath = "//div[@class='widgets__item__text__inside']//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("19df7bef-b4dd-4a35-991a-49c9a28ebfeb"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("3291c20c-0487-47a3-a428-fdcb0bdde0b6"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("0cea5575-ec4f-4b14-a0cc-49185e1d1768"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("6b286540-6b0b-42b6-a696-aed7dd5844c8"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("350279da-c53a-42a7-abad-a3097a881261"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("7258af78-93ae-46b1-9c4a-418769158262"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("f0a00f38-8859-4603-91db-251ada2ae73e"),
                NewsUrlXPath = "//a[starts-with(@href, '/news/')]/@href",
                NewsSiteUrl = "https://ren.tv/news/"
            };
        }
    }
}
