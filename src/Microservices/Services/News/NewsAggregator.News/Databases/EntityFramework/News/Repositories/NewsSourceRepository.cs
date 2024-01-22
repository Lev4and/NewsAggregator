using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.Entities;
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
                .Include(newsSource => newsSource.Logo)
                .ToListAsync();
        }

        public async Task<IReadOnlyCollection<NewsSource>> FindNewsSourcesExtendedAsync(
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.NewsSources.AsNoTracking()
                .Include(newsSource => newsSource.Logo)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParseEditorSettings)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParsePictureSettings)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParseSubTitleSettings)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParsePublishedAtSettings)
                .Include(newsSource => newsSource.SearchSettings)
                .ToListAsync();
        }

        public async Task<NewsSource?> FindNewsSourceByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.NewsSources.AsNoTracking()
                .Include(newsSource => newsSource.Logo)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParseEditorSettings)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParsePictureSettings)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParseSubTitleSettings)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParsePublishedAtSettings)
                .Include(newsSource => newsSource.SearchSettings)
                .SingleOrDefaultAsync(newsSource => newsSource.Id == id);
        }

        public async Task<NewsSource?> FindNewsSourceBySiteUrlAsync(string siteUrl, 
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.NewsSources.AsNoTracking()
                .Include(newsSource => newsSource.Logo)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParseEditorSettings)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParsePictureSettings)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParseSubTitleSettings)
                .Include(newsSource => newsSource.ParseSettings)
                    .ThenInclude(parseSettings => parseSettings.ParsePublishedAtSettings)
                .Include(newsSource => newsSource.SearchSettings)
                .SingleOrDefaultAsync(newsSource => newsSource.SiteUrl == siteUrl);
        }
    }
}
