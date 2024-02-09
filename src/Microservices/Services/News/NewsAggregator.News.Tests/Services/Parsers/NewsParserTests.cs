using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.NewsSources;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;
using System.Collections.Concurrent;
using Xunit.Abstractions;

namespace NewsAggregator.News.Tests.Services.Parsers
{
    public class NewsParserTests
    {
        private readonly INewsListHtmlPageProvider _newsListHtmlPageProvider;
        private readonly INewsHtmlPageProvider _newsHtmlPageProvider;
        private readonly INewsUrlsParser _newsUrlsParser;
        private readonly INewsParser _newsParser;
        private readonly Sources _sources;

        private readonly ITestOutputHelper _output;

        public NewsParserTests(INewsListHtmlPageProvider newsListHtmlPageProvider, INewsHtmlPageProvider newsHtmlPageProvider, 
            INewsUrlsParser newsUrlsParser, INewsParser newsParser, Sources sources, ITestOutputHelper output)
        {
            _newsListHtmlPageProvider = newsListHtmlPageProvider;
            _newsHtmlPageProvider = newsHtmlPageProvider;
            _newsUrlsParser = newsUrlsParser;
            _newsParser = newsParser;
            _sources = sources;

            _output = output;
        }

        [Theory]
        [InlineData("https://www.hltv.org/news/38143/eternal-fires-katowice-run-ended-by-navi")]
        public async Task ParseAsync_SpecificNewsUrl_ReturnNotNullResult(string newsUrl)
        {
            var newsSource = _sources[new Uri(newsUrl)];

            var news = await ParseNewsAsync(newsUrl, newsSource);

            _output.WriteLine("\nReport:\n");

            _output.WriteLine("URL: {0}", news.Url);
            _output.WriteLine("Title: {0}", news.Title);
            _output.WriteLine("Sub title: {0}", news.SubTitle);
            _output.WriteLine("Picture URL: {0}", news.PictureUrl);
            _output.WriteLine("Video URL: {0}", news.VideoUrl);
            _output.WriteLine("Editor name: {0}", news.EditorName);
            _output.WriteLine("Published at: {0:dd.MM.yyyy HH:mm:ss}", news.PublishedAt);
            _output.WriteLine("Modified at: {0:dd.MM.yyyy HH:mm:ss}", news.ModifiedAt);

            Assert.NotNull(news);
        }

        [Fact]
        public async Task ParseAsync_SpecificNewsSource_ReturnNotEmptyResult()
        {
            var newsSource = _sources[new Uri("https://www.hltv.org/")];

            var newsUrls = await ParseNewsUrlsAsync(newsSource);
            var newsUrlsEnumerator = newsUrls.GetEnumerator();

            var parsedNews = new ConcurrentBag<NewsDto>();
            var notParsedNews = new ConcurrentDictionary<string, Exception>();

            await ParseNewsMultithreadedAsync(newsUrlsEnumerator, newsSource, (newsUrl, task) => parsedNews.Add(task.Result), 
                (newsUrl, task) => notParsedNews.TryAdd(newsUrl, task.Exception));

            OutputReportParseNews(newsSource, newsUrls, parsedNews, notParsedNews);

            Assert.NotEmpty(parsedNews);
        }

        [Theory]
        [ClassData(typeof(NewsParserTestsData.NewsSources))]
        public async Task ParseAsync_EachNewsSource_ReturnNotEmptyResult(NewsSource newsSource)
        {
            var newsUrls = await ParseNewsUrlsAsync(newsSource);
            var newsUrlsEnumerator = newsUrls.GetEnumerator();

            var parsedNews = new ConcurrentBag<NewsDto>();
            var notParsedNews = new ConcurrentDictionary<string, Exception>();

            await ParseNewsMultithreadedAsync(newsUrlsEnumerator, newsSource, (newsUrl, task) => parsedNews.Add(task.Result), 
                (newsUrl, task) => notParsedNews.TryAdd(newsUrl, task.Exception));

            OutputReportParseNews(newsSource, newsUrls, parsedNews, notParsedNews);

            Assert.NotEmpty(parsedNews);
        }

        private async Task ParseNewsMultithreadedAsync(IEnumerator<string> newsUrlsEnumerator, NewsSource newsSource,
            Action<string, Task<NewsDto>> continuationOnCompletionAction, Action<string, Task<NewsDto>> continuationOnFaultedAction)
        {
            var tasks = new List<Task>();
            var maxTaskCount = 25;

            var isEndedNewsUrls = false;

            do
            {
                while (tasks.Count < maxTaskCount && !isEndedNewsUrls)
                {
                    var newsUrl = newsUrlsEnumerator.Current;

                    var task = ParseNewsAsync(newsUrl, newsSource);

                    task.ContinueWith(task => continuationOnCompletionAction(newsUrl, task), 
                        TaskContinuationOptions.OnlyOnRanToCompletion);

                    task.ContinueWith(task => continuationOnFaultedAction(newsUrl, task), 
                        TaskContinuationOptions.OnlyOnFaulted);

                    tasks.Add(task);

                    if (!newsUrlsEnumerator.MoveNext()) isEndedNewsUrls = true;
                }

                await Task.WhenAny(tasks);

                tasks.RemoveAll(task => task.IsCompleted);
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

        private async Task<NewsDto> ParseNewsAsync(string newsUrl, NewsSource newsSource)
        {
            if (newsSource.ParseSettings is null)
            {
                throw new NullReferenceException(nameof(newsSource.ParseSettings));
            }

            var html = await _newsHtmlPageProvider.ProvideAsync(newsUrl);

            return await _newsParser.ParseAsync(newsUrl, html, 
                newsSource.ParseSettings.ToNewsParserOptions());
        }

        private void OutputReportParseNews(NewsSource newsSource, IReadOnlyCollection<string> newsUrls, 
            IReadOnlyCollection<NewsDto> parsedNews, IReadOnlyDictionary<string, Exception> notParsedNews)
        {
            _output.WriteLine("\nInput data:\n");

            _output.WriteLine("News source title: {0}", newsSource.Title);

            _output.WriteLine("\nReport:\n");

            _output.WriteLine("Parsed news {0} from {1} ({2:P2})", parsedNews.Count, newsUrls.Count,
                (double)parsedNews.Count / (double)newsUrls.Count);

            var newsUrlsWithoutTitle = parsedNews.Where(news => string.IsNullOrEmpty(news.Title))
                .Select(news => news.Url)
                .ToList();

            if (newsUrlsWithoutTitle.Count > 0)
            {
                _output.WriteLine("\nParsed news without title {0} from {1} ({2:P2})\n", newsUrlsWithoutTitle.Count, 
                    parsedNews.Count, (double)newsUrlsWithoutTitle.Count / (double)parsedNews.Count);

                foreach (var newsUrl in newsUrlsWithoutTitle)
                {
                    _output.WriteLine(newsUrl);
                }
            }

            var newsUrlsWithoutSubTitle = parsedNews.Where(news => string.IsNullOrEmpty(news.SubTitle))
                .Select(news => news.Url)
                .ToList();

            if (newsSource.ParseSettings?.ParseSubTitleSettings is not null && newsUrlsWithoutSubTitle.Count > 0)
            {
                _output.WriteLine("\nParsed news without subtitle {0} from {1} ({2:P2})\n", newsUrlsWithoutSubTitle.Count,
                    parsedNews.Count, (double)newsUrlsWithoutSubTitle.Count / (double)parsedNews.Count);

                foreach (var newsUrl in newsUrlsWithoutSubTitle)
                {
                    _output.WriteLine(newsUrl);
                }
            }

            var newsUrlsWithoutPictureUrl = parsedNews.Where(news => string.IsNullOrEmpty(news.PictureUrl))
                .Select(news => news.Url)
                .ToList();

            if (newsSource.ParseSettings?.ParsePictureSettings is not null && newsUrlsWithoutPictureUrl.Count > 0)
            {
                _output.WriteLine("\nParsed news without picture url {0} from {1} ({2:P2})\n", newsUrlsWithoutPictureUrl.Count,
                    parsedNews.Count, (double)newsUrlsWithoutPictureUrl.Count / (double)parsedNews.Count);

                foreach (var newsUrl in newsUrlsWithoutPictureUrl)
                {
                    _output.WriteLine(newsUrl);
                }
            }

            var newsUrlsWithoutVideoUrl = parsedNews.Where(news => string.IsNullOrEmpty(news.VideoUrl))
                .Select(news => news.Url)
                .ToList();

            if (newsSource.ParseSettings?.ParseVideoSettings is not null && newsUrlsWithoutVideoUrl.Count > 0)
            {
                _output.WriteLine("\nParsed news without video url {0} from {1} ({2:P2})\n", newsUrlsWithoutVideoUrl.Count,
                    parsedNews.Count, (double)newsUrlsWithoutVideoUrl.Count / (double)parsedNews.Count);

                foreach (var newsUrl in newsUrlsWithoutVideoUrl)
                {
                    _output.WriteLine(newsUrl);
                }
            }

            var newsUrlsWithoutDescription = parsedNews.Where(news => string.IsNullOrEmpty(news.Description))
                .Select(news => news.Url)
                .ToList();

            if (newsUrlsWithoutDescription.Count > 0)
            {
                _output.WriteLine("\nParsed news without description {0} from {1} ({2:P2})\n", newsUrlsWithoutDescription.Count,
                    parsedNews.Count, (double)newsUrlsWithoutDescription.Count / (double)parsedNews.Count);

                foreach (var newsUrl in newsUrlsWithoutDescription)
                {
                    _output.WriteLine(newsUrl);
                }
            }

            var newsUrlsWithoutEditorName = parsedNews.Where(news => string.IsNullOrEmpty(news.EditorName))
                .Select(news => news.Url)
                .ToList();

            if (newsSource.ParseSettings?.ParseEditorSettings is not null && newsUrlsWithoutEditorName.Count > 0)
            {
                _output.WriteLine("\nParsed news without editor name {0} from {1} ({2:P2})\n", newsUrlsWithoutEditorName.Count,
                    parsedNews.Count, (double)newsUrlsWithoutEditorName.Count / (double)parsedNews.Count);

                foreach (var newsUrl in newsUrlsWithoutEditorName)
                {
                    _output.WriteLine(newsUrl);
                }
            }

            var newsUrlsWithoutPublishedAt = parsedNews.Where(news => news.PublishedAt is null)
                .Select(news => news.Url)
                .ToList();

            if (newsSource.ParseSettings?.ParsePublishedAtSettings is not null && newsUrlsWithoutPublishedAt.Count > 0)
            {
                _output.WriteLine("\nParsed news without published at {0} from {1} ({2:P2})\n", newsUrlsWithoutPublishedAt.Count,
                    parsedNews.Count, (double)newsUrlsWithoutPublishedAt.Count / (double)parsedNews.Count);

                foreach (var newsUrl in newsUrlsWithoutPublishedAt)
                {
                    _output.WriteLine(newsUrl);
                }
            }

            var newsUrlsWithoutModifiedAt = parsedNews.Where(news => news.ModifiedAt is null)
                .Select(news => news.Url)
                .ToList();

            if (newsSource.ParseSettings?.ParseModifiedAtSettings is not null && newsUrlsWithoutModifiedAt.Count > 0)
            {
                _output.WriteLine("\nParsed news without modified at {0} from {1} ({2:P2})\n", newsUrlsWithoutModifiedAt.Count,
                    parsedNews.Count, (double)newsUrlsWithoutModifiedAt.Count / (double)parsedNews.Count);

                foreach (var newsUrl in newsUrlsWithoutModifiedAt)
                {
                    _output.WriteLine(newsUrl);
                }
            }

            if (notParsedNews.Count > 0)
            {
                _output.WriteLine("\nParsed news with error:\n");

                foreach (var item in notParsedNews)
                {
                    _output.WriteLine("An error occurred when parse news {0}. Description: {1}.",
                        item.Key, item.Value.Message);
                }
            }
        }
    }
}
