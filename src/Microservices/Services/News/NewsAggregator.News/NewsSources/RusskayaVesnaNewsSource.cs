using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class RusskayaVesnaNewsSource : NewsSource
    {
        public RusskayaVesnaNewsSource()
        {
            Id = Guid.Parse("b2fb23b4-3f6d-440c-9ec0-99216f233fd0");
            Title = "Русская весна";
            SiteUrl = "https://rusvesna.su/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("3ee815d8-a253-47c7-9084-22cddbb490d4"),
                Small = "https://rusvesna.su/favicon.ico",
                Original = "https://rusvesna.su/favicon.ico"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("9730da62-1ba7-4f35-a1e0-6b7a0d6c4e3f"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("83188472-1463-4bcf-8d36-6166906332ac"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("6939baf3-2726-4b72-9ef2-ad710cdecc88"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("c965a1d0-83b6-4018-a4a5-9c426a02943e"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[contains(@class, 'field-type-text-long')]/*",
                TextDescriptionXPath = "//div[contains(@class, 'field-type-text-long')]//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("191181df-86e6-43c2-9643-5e9bb0ad62ac"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("181a1d07-35cc-4e75-9a36-330c319c6590"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("8ff05689-5c68-4f41-9023-4bfead386fed"),
                    PublishedAtXPath = "//span[@class='submitted-by']/text()",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("a28a5ac8-e766-4c34-823a-a5703f3ef96b"),
                            Format = "dd.MM.yyyy \"-\" HH:mm"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("a62f2d07-0e56-4bdc-a6de-c061d313bea9"),
                    ModifiedAtXPath = "//meta[@property='og:updated_time']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("331d2e46-95f3-42de-9a4c-a7dd3312647a"),
                            Format = "yyyy-MM-dd HH:mm"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("4305d788-135a-4922-8cfb-7d5b8971835e"),
                NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                NewsSiteUrl = "https://rusvesna.su/news"
            };
        }
    }
}
