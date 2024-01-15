using NewsAggregator.News.Databases.EntityFramework.News.Entities;
using NewsAggregator.News.Services.Parsers;

namespace NewsAggregator.News.Extensions
{
    public static class NewsSearchSettingsExtensions
    {
        public static NewsUrlsParserOptions ToNewsUrlsParserOptions(this NewsSearchSettings settings)
        {
            return new NewsUrlsParserOptions
            {
                NewsUrlXPath = settings.NewsUrlXPath
            };
        }
    }
}
