using NewsAggregator.Domain.Infrastructure.Databases.Repositories;
using NewsAggregator.News.Databases.EntityFramework.News.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public interface INewsEditorRepository : IRepository<NewsEditor>
    {
        Task<NewsEditor> FindOneBySourceIdAndNameOrAddAsync(NewsEditor entity, Guid sourceId, string? name,
            CancellationToken cancellationToken = default);
    }
}
