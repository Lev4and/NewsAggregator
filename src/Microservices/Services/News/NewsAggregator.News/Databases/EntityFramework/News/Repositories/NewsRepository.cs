
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

        public async Task<Entities.News?> FindNewsByUrlAsync(string url, CancellationToken cancellationToken = default)
        {
            return await _dbContext.News
                .Include(news => news.Editor)
                    .ThenInclude(editor => editor.Source)
                        .ThenInclude(source => source.Logo)
                .Include(news => news.SubTitle)
                .Include(news => news.Picture)
                .Include(news => news.Description)
                .AsNoTracking()
                .SingleOrDefaultAsync(news => news.Url == url, cancellationToken);
        }
    }
}
