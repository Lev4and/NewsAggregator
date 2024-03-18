using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class AifNewsSource : NewsSource
    {
        public AifNewsSource()
        {
            Id = Guid.Parse("9268835d-553d-4fbe-a0cb-0545b8019c68");
            Title = "Аргументы и факты";
            SiteUrl = "https://aif.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("3472a1e0-4bf9-418a-8e9e-94830248020b"),
                Small = "https://aif.ru/img/icon/favicon-32x32.png?44f",
                Original = "https://aif.ru/img/icon/apple-touch-icon.png?44f"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("7c4772ef-afbb-4264-92b5-77389e8c0990"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("d194cd94-eb02-471e-900c-2f298405b7c5"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("3241b406-31e8-41a2-b9cd-efc585789d48"),
                    Tag = new PoliticsNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("e8ea5810-3cc4-46dd-84d7-eb7b5cbf3f3b"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='article_text']",
                TextDescriptionXPath = "//div[@class='article_text']//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("17461131-afc7-41bd-af3b-0f2cda2dd935"),
                    NameXPath = "//div[@class='article_top']//div[@class='authors']//div[@class='autor']//span/text()",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("de397d9b-55d7-45f3-b03b-66584a58d137"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("c8d55c4c-0a8b-4133-b85d-6ca0df5a5671"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("21890de7-31ad-4c9e-a749-05f565d45905"),
                    PublishedAtXPath = "//div[@class='article_top']//div[@class='date']//time/text()",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("098793a2-d99d-494b-afba-e727e26214b7"),
                            Format = "dd.MM.yyyy HH:mm"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("1dde178c-c061-428a-b0e3-1d7b7ddc5c7b"),
                NewsSiteUrl = "https://aif.ru/",
                NewsUrlXPath = "//span[contains(@class, 'item_text__title')]/../@href"
            };
        }
    }
}
