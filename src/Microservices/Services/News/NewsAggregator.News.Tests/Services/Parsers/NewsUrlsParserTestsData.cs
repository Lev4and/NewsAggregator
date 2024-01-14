using NewsAggregator.News.NewsSources;
using NewsAggregator.News.Services.Parsers;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsUrlsParserTestsData
    {
        public class NewsSources : TheoryData<string, NewsUrlsParserOptions>
        {
            public NewsSources()
            {
                var newsSources = new Sources();

                foreach (var newsSource in newsSources)
                {
                    if (newsSource.SearchSettings is not null)
                    {
                        Add(
                            newsSource.SearchSettings.NewsSiteUrl,
                            new NewsUrlsParserOptions
                            {
                                NewsUrlXPath = newsSource.SearchSettings.NewsUrlXPath
                            });
                    }
                }
            }
        }
    }
}
