using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Repositories
{
    public interface INewsTagRepository : IRepository<NewsTag>
    {
        Task<IReadOnlyCollection<NewsTag>> FindNewsTagsAsync(CancellationToken cancellationToken = default);

        Task<NewsTag?> FindNewsTagByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<NewsTag?> FindNewsTagByNameAsync(string name, CancellationToken cancellationToken = default);
    }
}
