using NewsAggregator.News.Entities;
using NewsAggregator.News.NewsSources;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsUrlsParserTestsData
    {
        public class NewsSources : TheoryData<NewsSource>
        {
            public NewsSources()
            {
                var enabledNewsSources = new Sources().Where(source => source.IsEnabled);

                foreach (var newsSource in enabledNewsSources)
                {
                    Add(newsSource);
                }
            }
        }
    }
}
