using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Repositories
{
    public interface INewsEditorRepository : IRepository<NewsEditor>
    {
        Task<IReadOnlyCollection<NewsEditor>> FindNewsEditorsAsync(CancellationToken cancellationToken = default);

        Task<NewsEditor?> FindNewsEditorByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<NewsEditor> FindOneBySourceIdAndNameOrAddAsync(NewsEditor entity, Guid sourceId, string? name,
            CancellationToken cancellationToken = default);
    }
}
