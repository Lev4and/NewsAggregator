namespace NewsAggregator.News.Services.Parsers
{
    public interface INewsUrlsParser
    {
        Task<IReadOnlyCollection<string>> ParseAsync(string newsSiteUrl, string html, NewsUrlsParserOptions options,
            CancellationToken cancellationToken = default);
    }
}
