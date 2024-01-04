using NewsAggregator.News.DTOs;

namespace NewsAggregator.News.Services.Parsers
{
    public interface INewsParser
    {
        Task<NewsDto> ParseAsync(string newsUrl, NewsParserOptions options, 
            CancellationToken cancellationToken = default);
    }
}
