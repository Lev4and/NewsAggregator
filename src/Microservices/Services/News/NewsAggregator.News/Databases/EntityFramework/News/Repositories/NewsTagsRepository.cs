using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public class NewsTagsRepository : NewsDbRepository<NewsTag>, INewsTagsRepository
    {
        public NewsTagsRepository(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<NewsTag?> FindNewsTagByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindOneByIdAsync(id, cancellationToken);
        }

        public async Task<IReadOnlyCollection<NewsTag>> FindNewsTagsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.NewsTags.AsNoTracking()
                .OrderBy(tag => tag.Name)
                .ToListAsync();
        }
    }
}
