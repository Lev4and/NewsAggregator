namespace NewsAggregator.News.Services.Providers
{
    public interface INewsHtmlPageProvider
    {
        Task<string> ProvideAsync(string url, CancellationToken cancellationToken = default);
    }
}
