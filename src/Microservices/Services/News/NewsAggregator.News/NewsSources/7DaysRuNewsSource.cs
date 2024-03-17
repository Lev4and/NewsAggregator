using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class _7DaysRuNewsSource : NewsSource
    {
        public _7DaysRuNewsSource()
        {
            Id = Guid.Parse("ba078388-eedf-4ccb-af5f-3f686f4ece4a");
            Title = "7дней.ru";
            SiteUrl = "https://7days.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("d227ada8-0869-4320-8e0b-29b4b57ace6f"),
                Small = "https://7days.ru/favicon-32x32.png",
                Original = "https://7days.ru/android-icon-192x192.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("0ee0d08c-66c0-4f83-ad46-92e3971d13d8"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("e19e6158-1b33-4f1b-9757-6b50f180f007"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.ShowBusinessNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("692ba156-95b9-4a24-9b0c-71b769e8d3a8"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='material-7days__paragraf-content']/*[not(name()='div' and @itemprop='image' and position()=1)]",
                TextDescriptionXPath = "//div[@class='material-7days__paragraf-content']//p//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("255720d2-2188-4d40-ac74-86e2f87c78c7"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("efc3e79b-1827-40e8-a072-7f1cac6e991b"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("9bfd49d6-dcb9-4a65-80f5-c9ac3b6b490d"),
                    PublishedAtXPath = "//meta[@itemprop='datePublished']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("d70086c1-dd34-40a7-b8d5-225689fd993c"),
                            Format = "yyyy-MM-dd"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("6dc53704-3d38-47f9-9efa-7604da400355"),
                    ModifiedAtXPath = "//meta[@itemprop='dateModified']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("d5896f93-bbef-44cb-82c4-6c0c73e4f4c9"),
                            Format = "yyyy-MM-dd"
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("62fe0769-6882-48b6-91c1-0f7a205aca05"),
                NewsUrlXPath = "//a[contains(@class, '7days__item_href') and starts-with(@href, '/news/')]/@href",
                NewsSiteUrl = "https://7days.ru/news/"
            };
        }
    }
}
