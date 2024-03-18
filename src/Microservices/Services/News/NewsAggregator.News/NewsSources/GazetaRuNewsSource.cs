using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class GazetaRuNewsSource : NewsSource
    {
        public GazetaRuNewsSource()
        {
            Id = Guid.Parse("cc29eb91-2efb-4d57-8d14-bb5356cbfbb8");
            Title = "Газета.Ru";
            SiteUrl = "https://www.gazeta.ru/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("d7e0f8bc-64ec-4450-b8bb-82689f1d9012"),
                Small = "https://static.gazeta.ru/nm2021/img/icons/favicon.svg",
                Original = "https://static.gazeta.ru/nm2021/img/icons/favicon.svg"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("025c4e26-53d0-469f-9c52-3cec92eda13a"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("25a4e9e3-c047-485a-9684-c3f897c6d8b8"),
                    Tag = new RussiaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("fa9322b8-0640-43ea-847f-4a05bf1b160d"),
                    Tag = new PoliticsNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("60a60886-4da0-4c2c-8635-a8ec57827667"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*",
                TextDescriptionXPath = "//div[@itemprop='articleBody']/*//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("91108b0c-0f51-4946-b639-e9b8e67c48b9"),
                    NameXPath = "//div[@class='author']/span[@itemprop='author']/span[@itemprop='name']/a/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("c9ff2c75-e65b-4fb4-a3a0-789c15973fac"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("34d00cc0-a590-4e50-a6d8-6c4c7511c4d8"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("b208c066-da95-4c32-baec-ff448a07f62d"),
                    PublishedAtXPath = "//meta[@itemprop='dateModified']/@content",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("5161d08b-a97d-4fa1-ad5a-069c3b5dc41a"),
                            Format = "yyyy-MM-ddTHH:mm:sszzz"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("b8e85938-97a8-47bf-aa33-c5bca3708e0e"),
                NewsSiteUrl = "https://www.gazeta.ru/news/",
                NewsUrlXPath = "//a[contains(@href, '/news/') and contains(@href, '.shtml') and not(contains(@href, '?'))]/@href"
            };
        }
    }
}
