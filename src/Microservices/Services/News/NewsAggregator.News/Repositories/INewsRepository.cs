using NewsAggregator.Domain.Repositories;

namespace NewsAggregator.News.Repositories
{
    public interface INewsRepository : IRepository<Entities.News>
    {
        Task<bool> ContainsNewsByUrlAsync(string url, CancellationToken cancellationToken = default);

        Task<IReadOnlyDictionary<string, bool>> ContainsNewsByUrlsAsync(IReadOnlyCollection<string> urls, 
            CancellationToken cancellationToken = default);

        Task<Entities.News?> FindNewsByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Entities.News?> FindNewsByUrlAsync(string url, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<Entities.News>> FindRecentNewsAsync(int count, CancellationToken cancellationToken = default);
    }
}
