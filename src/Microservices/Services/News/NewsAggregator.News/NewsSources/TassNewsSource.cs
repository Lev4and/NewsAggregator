using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class TassNewsSource : NewsSource
    {
        public TassNewsSource()
        {
            Id = Guid.Parse("7e889af8-0f19-44ab-96d4-241fd64fbcdb");
            Title = "ТАСС";
            SiteUrl = "https://tass.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("29e9a963-8850-4c05-9714-a4b59af20be4"),
                Small = "https://tass.ru/favicon/57.png",
                Original = "https://tass.ru/favicon/180.svg"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("bc9d7be6-2e7e-4b7c-9859-b8047ce7ef81"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("20725e40-3f1d-4089-8d74-9d08ae3f127d"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussiaNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("33e821e2-c90d-45ed-a905-269ca20bf28f"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.PoliticsNewsTag
                    }
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("28bff881-79f7-400c-ab5d-489176c269bb"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//article/*",
                TextDescriptionXPath = "//article/*//text()",
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("afb5bb1e-5cb0-4176-b2e0-99f6efb399dd"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("c8a3d258-c774-4ac2-85ae-08f7ede167d4"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("076e2817-f0e0-4f4a-ae55-08210a7e1a7d"),
                    PublishedAtXPath = "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark')]//span[@ca-ts]/text()",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "UTC",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("da39c45c-178d-4b8c-8944-9d77de2690d0"),
                            Format = "d MMMM yyyy, HH:mm"
                        },
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("2f4dba30-cd44-4a34-a28b-50d3d6db53d1"),
                            Format = "d MMMM yyyy, HH:mm,"
                        },
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("509eae6c-481c-4a9d-9a9a-bd20b2ae533e"),
                            Format = "d MMMM, HH:mm"
                        },
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("3d264810-c568-4d66-9762-43c1467a6cd2"),
                            Format = "d MMMM, HH:mm,"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("307744f1-4338-481a-b849-b8d88c196cc3"),
                    ModifiedAtXPath = "//div[contains(@class, 'NewsHeader')]//div[contains(@class, 'PublishedMark_update')]//span[@ca-ts]/text()",
                    ModifiedAtCultureInfo = "ru-RU",
                    ModifiedAtTimeZoneInfoId = "UTC",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("4084a0b1-75dd-4ab0-9b43-d2d569dfc7c7"),
                            Format = "\"обновлено\" d MMMM yyyy, HH:mm"
                        },
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("61a158be-a01d-42c1-a474-2bbc66775a60"),
                            Format = "\"обновлено\" d MMMM, HH:mm"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("022c7083-ea41-4e42-b40e-a0d72dfb7956"),
                NewsSiteUrl = "https://tass.ru/",
                NewsUrlXPath = "//a[contains(@class, 'tass_pkg_link-v5WdK') and contains(substring(@href, 2), '/') and not(contains(@href, '/spec/')) and not(contains(@href, 'spec.tass.ru'))]/@href"
            };
        }
    }
}
