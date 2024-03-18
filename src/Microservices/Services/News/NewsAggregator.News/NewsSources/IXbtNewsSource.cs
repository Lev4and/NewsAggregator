using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;

namespace NewsAggregator.News.NewsSources
{
    public class IXbtNewsSource : NewsSource
    {
        public IXbtNewsSource()
        {
            Id = Guid.Parse("e023416d-7d91-4d92-bd5f-37d57c54f6b4");
            Title = "iXBT.com";
            SiteUrl = "https://www.ixbt.com/";
            IsSystem = true;
            IsEnabled = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("427cf0f1-b0ef-4ab9-b181-63710edcf220"),
                Small = "https://www.ixbt.com/favicon.ico",
                Original = "https://www.ixbt.com/favicon.ico"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("5136ab36-5504-49e6-9422-0afeff788cbf"),
                    Tag = new RussianNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("fc69d2fa-df60-45d6-8e79-41105f488cbf"),
                    Tag = new InformationTechnologiesNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("f534eefe-6616-4631-8354-c8e86140632b"),
                    Tag = new TechnologiesNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("688e1338-51ad-40c5-a537-4fcc91fd0ed0"),
                    Tag = new ComputerHardwareNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("96ef6e5b-c81b-45e7-a715-1aa131d82ef2"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@itemprop='articleBody']/*[position()>2]",
                TextDescriptionXPath = "//div[@itemprop='articleBody']/*[position()>2]//text()",
                ParseEditorSettings = new NewsParseEditorSettings
                {
                    Id = Guid.Parse("f6679100-82e3-4e0d-98a9-de90246ccf3a"),
                    NameXPath = "//span[@itemprop='author']/span[@itemprop='name']/@content",
                    IsRequired = false
                },
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("df87f204-4c84-408d-b84b-392e39d40b1f"),
                    TitleXPath = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("7bf75c22-3ba4-42df-987a-468cbae9d132"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("fed30888-ff5a-4843-8a23-fa452ed88675"),
                    PublishedAtXPath = "//div[@class='b-article__top-author']/p[@class='date']/text()",
                    PublishedAtCultureInfo = CultureInfoConstants.RussianRussiaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.RussianStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat>
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("63435dc7-a82d-43d8-80e9-f5e1307ec3ab"),
                            Format = "d MMMM yyyy \"в\" HH:mm"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("890e7953-5769-4023-922c-45094cb89251"),
                NewsSiteUrl = "https://www.ixbt.com/news/",
                NewsUrlXPath = "//a[starts-with(@href, '/news/') and contains(@href, '.html') and not(contains(@href, '#comments'))]/@href"
            };
        }
    }
}
