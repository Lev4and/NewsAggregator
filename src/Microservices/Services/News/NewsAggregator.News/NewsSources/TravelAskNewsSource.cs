using NewsAggregator.News.Entities;

namespace NewsAggregator.News.NewsSources
{
    public class TravelAskNewsSource : NewsSource
    {
        public TravelAskNewsSource()
        {
            Id = Guid.Parse("b9ec9be8-e1f2-49d6-b461-b61872bb369c");
            Title = "TravelAsk";
            SiteUrl = "https://travelask.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("915e2d86-b519-4034-a44f-991b0a446607"),
                Small = "https://s9.travelask.ru/favicons/favicon-32x32.png",
                Original = "https://s9.travelask.ru/favicons/apple-touch-icon-180x180.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("374ede54-919b-4c31-9738-18b31de40898"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.RussianNewsTag
                    }
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("bad63cda-47c7-45ef-867c-c271c48b2e13"),
                    Tag = new NewsTag
                    {
                        Name = NewsTags.Tags.TravelNewsTag
                    }
                }
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("52ac2f5a-3b95-4adc-9c2a-abd192a1ec26"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                TextDescriptionXPath = "//div[@itemprop='articleBody']//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("c8e216e4-355b-42c5-babf-cb9ae005b27c"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("a7340062-15ee-4ea9-b6c5-1ea46f299c49"),
                    NameXPath = "//div[@class='blog-post-info']//div[@itemprop='author']//span[@itemprop='name']/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("9fcdbc5c-80af-454f-84f8-a8411f6b0184"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("eaf8f8a4-7781-4285-b447-1e3309b2edbf"),
                    PublishedAtXPath = "//meta[@property='article:published_time']/@content",
                    PublishedAtCultureInfo = "ru-RU",
                    PublishedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("05a46c75-81a5-4b37-b01f-7ef41ba35858"),
                            Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("4aeb273b-8983-4ed7-adf0-74ff9bdfb4ab"),
                    ModifiedAtXPath = "//meta[@property='article:modified_time']/@content",
                    ModifiedAtCultureInfo = "ru-RU",
                    ModifiedAtTimeZoneInfoId = "Russian Standard Time",
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat>
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("b86762b0-61e7-4b60-8d55-84285b2ba9f9"),
                            Format = "yyyy-MM-ddTHH:mm:ss\"+0300\""
                        }
                    }
                },
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("a13340f1-b8ad-4aed-8db3-3ce1bc26b977"),
                NewsUrlXPath = "//a[not(@href='/news/') and starts-with(@href, '/news/')]/@href",
                NewsSiteUrl = "https://travelask.ru/news"
            };
        }
    }
}
