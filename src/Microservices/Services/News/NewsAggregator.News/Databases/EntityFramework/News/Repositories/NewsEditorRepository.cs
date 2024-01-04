using NewsAggregator.News.Databases.EntityFramework.News.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public class NewsEditorRepository : NewsDbRepository<NewsEditor>, INewsEditorRepository
    {
        public NewsEditorRepository(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<NewsEditor> FindOneBySourceIdAndNameOrAddAsync(NewsEditor entity, Guid sourceId, string? name, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, editor => editor.SourceId == sourceId &&
                editor.Name == name, cancellationToken);
        }
    }
}
