
using MassTransit;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public class NewsRepository : NewsDbRepository<Entities.News>, INewsRepository
    {
        public NewsRepository(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> ContainsNewsByUrlAsync(string url, CancellationToken cancellationToken = default)
        {
            return await _dbContext.News.AsNoTracking().SingleOrDefaultAsync(news => news.Url == url, cancellationToken) != null ||
                await _dbContext.NewsParseErrors.AsNoTracking().SingleOrDefaultAsync(error => error.NewsUrl == url, cancellationToken) != null;
        }

        public async Task<IReadOnlyDictionary<string, bool>> ContainsNewsByUrlsAsync(IReadOnlyCollection<string> urls, 
            CancellationToken cancellationToken = default)
        {
            var newsUrls = await _dbContext.News.AsNoTracking()
                .Where(news => urls.Contains(news.Url))
                .Select(news => news.Url)
                .Union(_dbContext.NewsParseErrors.AsNoTracking()
                    .Where(news => urls.Contains(news.NewsUrl))
                    .Select(news => news.NewsUrl))
                .Distinct()
                .ToListAsync();

            return urls.Distinct().ToDictionary(key => key, newsUrls.Contains);
        }

        public async Task<Entities.News?> FindNewsByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.News
                .Include(news => news.Editor)
                    .ThenInclude(editor => editor.Source)
                        .ThenInclude(source => source.Logo)
                .Include(news => news.SubTitle)
                .Include(news => news.Picture)
                .Include(news => news.Description)
                .AsNoTracking()
                .SingleOrDefaultAsync(news => news.Id == id, cancellationToken);
        }

        public async Task<Entities.News?> FindNewsByUrlAsync(string url, CancellationToken cancellationToken = default)
        {
            return await _dbContext.News.AsNoTracking()
                .Include(news => news.Editor)
                    .ThenInclude(editor => editor.Source)
                        .ThenInclude(source => source.Logo)
                .Include(news => news.SubTitle)
                .Include(news => news.Picture)
                .Include(news => news.Description)
                .SingleOrDefaultAsync(news => news.Url == url, cancellationToken);
        }

        public async Task<IReadOnlyCollection<Entities.News>> FindRecentNewsAsync(int count, bool subTitleRequired = false,
            bool pictureRequired = false, CancellationToken cancellationToken = default)
        {
            var query = (IQueryable<Entities.News>)_dbContext.News.AsNoTracking()
                .Include(news => news.Editor)
                    .ThenInclude(editor => editor.Source)
                        .ThenInclude(source => source.Logo)
                .Include(news => news.SubTitle)
                .Include(news => news.Picture);

            if (subTitleRequired)
            {
                query = query.Where(news => news.SubTitle != null);
            }

            if (pictureRequired)
            {
                query = query.Where(news => news.Picture != null);
            }

            query = query.OrderByDescending(news => news.PublishedAt)
                .Take(count);

            return await query.ToListAsync(cancellationToken);
        }
    }
}
