using NewsAggregator.News.Constants;
using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsTags;
using System.Runtime.InteropServices;

namespace NewsAggregator.News.NewsSources
{
    public class PoliticoNewsSource : NewsSource
    {
        public PoliticoNewsSource()
        {
            Id = Guid.Parse("7c0ac71c-0e8e-425b-ac26-424b152415f5");
            Title = "POLITICO";
            SiteUrl = "https://www.politico.com/";
            IsEnabled = true;
            IsSystem = true;
            Logo = new NewsSourceLogo
            {
                Id = Guid.Parse("cdfd8be8-f692-48f3-a06d-e290f20d92e2"),
                Small = "https://www.politico.com/favicon-32x32.png",
                Original = "https://www.politico.com/apple-touch-icon-180x180.png"
            };
            Tags = new List<NewsSourceTag>
            {
                new NewsSourceTag
                {
                    Id = Guid.Parse("acc922e5-bf8f-4bd7-bc82-7e75d87bc245"),
                    Tag = new EnglishNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("996ec670-045e-45e0-bb3b-d0218e36704d"),
                    Tag = new UsaNewsTag()
                },
                new NewsSourceTag
                {
                    Id = Guid.Parse("cc81438d-b3a7-44cb-bb91-7b8b01b2b700"),
                    Tag = new PoliticsNewsTag()
                },
            };
            ParseSettings = new NewsParseSettings
            {
                Id = Guid.Parse("1a5ca4c2-2984-4c52-9fa2-d7f564fd6add"),
                TitleXPath = "//meta[@property='og:title']/@content",
                HtmlDescriptionXPath = "//div[@class='sidebar-grid__content article__content']",
                TextDescriptionXPath = "//div[@class='sidebar-grid__content article__content']//text()",
                ParseSubTitleSettings = new NewsParseSubTitleSettings
                {
                    Id = Guid.Parse("f7cd72a9-93c2-4f46-b76c-65cbe87a49ef"),
                    TitleXPath  = "//meta[@property='og:description']/@content",
                    IsRequired = false
                },
                ParseEditorSettings = new NewsParseEditorSettings 
                {
                    Id = Guid.Parse("eabe266c-ac67-4803-8901-6deb6edfa5e6"),
                    NameXPath = "//div[@class='story-meta']//p[@class='story-meta__authors']/span[@class='vcard']/a/text()",
                    IsRequired = false
                },
                ParsePictureSettings = new NewsParsePictureSettings
                {
                    Id = Guid.Parse("eb0cb4fc-8982-465c-87a0-d5a83e2c579a"),
                    UrlXPath = "//meta[@property='og:image']/@content",
                    IsRequired = false
                },
                ParsePublishedAtSettings = new NewsParsePublishedAtSettings
                {
                    Id = Guid.Parse("2dfea686-66c2-4b59-86cf-01fdce1da6c5"),
                    PublishedAtXPath = "//div[@class='story-meta']//p[@class='story-meta__timestamp']/time/@datetime",
                    PublishedAtCultureInfo = CultureInfoConstants.EnglishUsaCultureInfoName,
                    PublishedAtTimeZoneInfoId = TimeZoneConstants.EasternStandardTimeTimeZoneId,
                    IsRequired = true,
                    Formats = new List<NewsParsePublishedAtSettingsFormat> 
                    {
                        new NewsParsePublishedAtSettingsFormat
                        {
                            Id = Guid.Parse("0ab06b9d-5327-4461-9493-a01ff9b37dfa"),
                            Format = "yyyy-MM-dd HH:mm:ss"
                        }
                    }
                },
                ParseModifiedAtSettings = new NewsParseModifiedAtSettings
                {
                    Id = Guid.Parse("ac1075c5-1536-4691-bc44-c67665d0e2e2"),
                    ModifiedAtXPath = "//div[@class='story-meta']//p[@class='story-meta__updated']/time/@datetime",
                    ModifiedAtCultureInfo = CultureInfoConstants.EnglishUsaCultureInfoName,
                    ModifiedAtTimeZoneInfoId = TimeZoneConstants.EasternStandardTimeTimeZoneId,
                    IsRequired = false,
                    Formats = new List<NewsParseModifiedAtSettingsFormat> 
                    {
                        new NewsParseModifiedAtSettingsFormat
                        {
                            Id = Guid.Parse("1ae044f9-a228-41a3-a0c1-a708c760fe88"),
                            Format = "yyyy-MM-dd HH:mm:ss"
                        }
                    }
                }
            };
            SearchSettings = new NewsSearchSettings
            {
                Id = Guid.Parse("93606f5a-dd33-4a66-8c13-d718d2082e07"),
                NewsUrlXPath = "//a[starts-with(@href, 'https://www.politico.com/news/')]/@href",
                NewsSiteUrl = "https://www.politico.com/"
            };
        }
    }
}
