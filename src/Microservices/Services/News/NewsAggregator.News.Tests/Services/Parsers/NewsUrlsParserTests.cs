using NewsAggregator.News.Databases.EntityFramework.News.Entities;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.NewsSources;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;
using Xunit.Abstractions;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsUrlsParserTests
    {
        private readonly INewsListHtmlPageProvider _newsListHtmlPageProvider;
        private readonly INewsUrlsParser _newsUrlsParser;

        private readonly ITestOutputHelper _output;

        public NewsUrlsParserTests(INewsListHtmlPageProvider newsListHtmlPageProvider, INewsUrlsParser newsUrlsParser, 
            ITestOutputHelper output)
        {
            _newsListHtmlPageProvider = newsListHtmlPageProvider;
            _newsUrlsParser = newsUrlsParser;

            _output = output;
        }

        [Theory]
        [ClassData(typeof(NewsUrlsParserTestsData.NewsSources))]
        public async Task ParseAsync_EachNewsSource_ReturnNotEmptyResult(NewsSource newsSource)
        {
            var newsUrls = await ParseNewsUrlsAsync(newsSource);

            _output.WriteLine("\nReport:\n");

            _output.WriteLine("Found {0} news items from \"{1}\" news source", newsUrls.Count, newsSource.Title);

            Assert.NotEmpty(newsUrls);
        }

        [Fact]
        public async Task ParseAsync_AllNewsSources_ReturnNotEmptyResult()
        {
            var newsSourceEnumerator = new Sources().Where(source => source.IsEnabled)
                .GetEnumerator();

            var result = new Dictionary<string, int>();

            await ParseNewsUrlsMultithreadedAsync(newsSourceEnumerator, 
                (newsSource, newsUrls) => result.Add(newsSource.Title, newsUrls.Result.Count),
                (newsSource, newsUrls) => result.Add(newsSource.Title, 0));

            _output.WriteLine("\nReport:\n");

            foreach (var item in result)
            {
                _output.WriteLine("Found {0} news items from \"{1}\" news source", item.Value, item.Key);
            }

            _output.WriteLine("\n{0} news items found\n", result.Sum(item => item.Value));

            Assert.NotEmpty(result);

            Assert.True(result.Values.All(value => value > 0));
        }

        private async Task ParseNewsUrlsMultithreadedAsync(IEnumerator<NewsSource> newsSourceEnumerator,
            Action<NewsSource, Task<IReadOnlyCollection<string>>> continuationOnCompletionAction, 
            Action<NewsSource, Task<IReadOnlyCollection<string>>> continuationOnFaultedAction)
        {
            var tasks = new List<Task>();
            var maxTaskCount = 25;

            var isEndedNewsSources = false;

            do
            {
                while (tasks.Count < maxTaskCount && !isEndedNewsSources)
                {
                    var newsSource = newsSourceEnumerator.Current;

                    var task = ParseNewsUrlsAsync(newsSource);

                    task.ContinueWith(task => continuationOnCompletionAction(newsSource, task),
                        TaskContinuationOptions.OnlyOnRanToCompletion);

                    task.ContinueWith(task => continuationOnFaultedAction(newsSource, task),
                        TaskContinuationOptions.OnlyOnFaulted);

                    tasks.Add(task);

                    if (!newsSourceEnumerator.MoveNext()) isEndedNewsSources = true;
                }

                await Task.WhenAny(tasks);

                tasks.RemoveAll(s => s.IsCompleted);
            }
            while (tasks.Any(task => !task.IsCompleted));
        }

        private async Task<IReadOnlyCollection<string>> ParseNewsUrlsAsync(NewsSource newsSource)
        {
            if (newsSource.SearchSettings is null)
            {
                throw new NullReferenceException(nameof(newsSource.SearchSettings));
            }

            var html = await _newsListHtmlPageProvider.ProvideAsync(newsSource.SearchSettings.NewsSiteUrl);

            return await _newsUrlsParser.ParseAsync(newsSource.SearchSettings.NewsSiteUrl, html,
                newsSource.SearchSettings.ToNewsUrlsParserOptions());
        }
    }
}
