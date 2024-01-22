using NewsAggregator.Domain.Infrastructure.Databases.Repositories;

namespace NewsAggregator.News.Repositories
{
    public interface INewsRepository : IRepository<Entities.News>
    {
        Task<bool> ContainsNewsByUrlAsync(string url, CancellationToken cancellationToken = default);

        Task<Entities.News?> FindNewsByUrlAsync(string url, CancellationToken cancellationToken = default);
    }
}
