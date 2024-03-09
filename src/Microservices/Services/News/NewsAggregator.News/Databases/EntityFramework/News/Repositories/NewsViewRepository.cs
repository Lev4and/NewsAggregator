using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public class NewsViewRepository : NewsDbRepository<NewsView>, INewsViewRepository
    {
        public NewsViewRepository(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> ContainsByNewsIdAndIpAddressAsync(Guid newsId, string ipAddress, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionAsync(view => view.NewsId == newsId 
                && view.IpAddress == ipAddress, cancellationToken) != null;
        }

        public async Task<long> GetCountViewsByNewsIdAsync(Guid newsId, 
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.NewsViews.AsNoTracking()
                .Where(view => view.NewsId == newsId)
                .CountAsync(cancellationToken);
        }
    }
}
