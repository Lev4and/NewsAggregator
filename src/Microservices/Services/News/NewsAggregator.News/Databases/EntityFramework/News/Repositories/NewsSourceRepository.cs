using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public class NewsSourceRepository : NewsDbRepository<NewsSource>, INewsSourceRepository
    {
        public NewsSourceRepository(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IReadOnlyCollection<NewsSource>> FindNewsSourcesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.NewsSources.AsNoTracking()
                .IncludeAll()
                .OrderBy(newsSource => newsSource.Title)
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<NewsSource>> FindAvailableNewsSourcesExtendedAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.NewsSources.AsNoTracking()
                .IncludeAll()
                .Where(newsSource => newsSource.IsEnabled)
                .ToListAsync();
        }

        public async Task<NewsSource?> FindNewsSourceByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.NewsSources.AsNoTracking()
                .IncludeAll()
                .SingleOrDefaultAsync(newsSource => newsSource.Id == id);
        }

        public async Task<NewsSource?> FindNewsSourceBySiteUrlAsync(string siteUrl, 
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.NewsSources.AsNoTracking()
                .IncludeAll()
                .SingleOrDefaultAsync(newsSource => newsSource.SiteUrl == siteUrl);
        }
    }
}
