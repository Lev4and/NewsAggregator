using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public class NewsTagRepository : NewsDbRepository<NewsTag>, INewsTagRepository
    {
        public NewsTagRepository(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IReadOnlyCollection<NewsTag>> FindNewsTagsAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.NewsTags.AsNoTracking()
                .OrderBy(tag => tag.Name)
                .ToListAsync();
        }

        public async Task<NewsTag?> FindNewsTagByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await FindOneByIdAsync(id, cancellationToken);
        }

        public async Task<NewsTag?> FindNewsTagByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionAsync(tag => tag.Name == name, cancellationToken);
        }
    }
}
