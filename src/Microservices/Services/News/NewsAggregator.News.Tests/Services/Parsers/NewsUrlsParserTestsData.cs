using NewsAggregator.News.DTOs;
using NewsAggregator.News.Services.Parsers;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsUrlsParserTestsData
    {
        public class NewsSources : TheoryData<string, NewsUrlsParserOptions>
        {
            public NewsSources()
            {
                var newsSourceDtos = new NewsSourceDtos();

                foreach (var newsSourceDto in newsSourceDtos)
                {
                    Add(newsSourceDto.NewsSiteUrl, new NewsUrlsParserOptions(newsSourceDto.SearchSettings.NewsUrlXPath));
                }
            }
        }
    }
}
