using NewsAggregator.News.DTOs;

namespace NewsAggregator.News.Services.Parsers
{
    public interface INewsParser
    {
        Task<NewsDto> ParseAsync(string newsUrl, string html, NewsParserOptions options, 
            CancellationToken cancellationToken = default);
    }
}
