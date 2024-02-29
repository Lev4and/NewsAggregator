using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public class NewsEditorRepository : NewsDbRepository<NewsEditor>, INewsEditorRepository
    {
        public NewsEditorRepository(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IReadOnlyCollection<NewsEditor>> FindNewsEditorsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<NewsEditor>().AsNoTracking()
                .Include(editor => editor.Source)
                .OrderBy(editor => editor.Name)
                .ToListAsync(cancellationToken);
        }

        public async Task<NewsEditor?> FindNewsEditorByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<NewsEditor>().AsNoTracking()
                .Include(editor => editor.Source)
                .SingleOrDefaultAsync(editor => editor.Id == id, cancellationToken);
        }

        public async Task<NewsEditor> FindOneBySourceIdAndNameOrAddAsync(NewsEditor entity, Guid sourceId, string name, 
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<NewsEditor>().AsNoTracking()
                .FirstOrDefaultAsync(editor => editor.SourceId == sourceId &&
                    editor.Name == name, cancellationToken) 
                ?? Add(entity);
        }
    }
}
