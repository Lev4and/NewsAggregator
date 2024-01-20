namespace NewsAggregator.News.Services.Providers
{
    public interface INewsListHtmlPageProvider
    {
        Task<string> ProvideAsync(string url, CancellationToken cancellationToken = default);
    }
}
