using NewsAggregator.News.DTOs;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsParserTestsData
    {
        public class NewsSources : TheoryData<NewsSourceDto>
        {
            public NewsSources()
            {
                var newsSourceDtos = new NewsSourceDtos();

                foreach (var newsSourceDto in newsSourceDtos)
                {
                    Add(newsSourceDto);
                }
            }
        }
    }
}
