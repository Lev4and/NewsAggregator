
using MassTransit;
using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Specification;
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
            return await _dbContext.News.AsNoTracking()
                .SingleOrDefaultAsync(news => news.Url == url, cancellationToken) != null;
        }

        public async Task<IReadOnlyDictionary<string, bool>> ContainsNewsByUrlsAsync(IReadOnlyCollection<string> urls, 
            CancellationToken cancellationToken = default)
        {
            var newsUrls = await _dbContext.News
                .AsNoTracking()
                    .Where(news => urls.Contains(news.Url))
                        .Select(news => news.Url)
                .Union(_dbContext.NewsParseNeeds
                    .AsNoTracking()
                        .Where(news => urls.Contains(news.NewsUrl))
                            .Select(news => news.NewsUrl))
                .Union(_dbContext.NewsParseErrors
                    .AsNoTracking()
                        .Where(news => urls.Contains(news.NewsUrl))
                            .Select(news => news.NewsUrl))
                .Union(_dbContext.NewsParseNetworkErrors
                    .AsNoTracking()
                        .Where(news => urls.Contains(news.NewsUrl))
                            .Select(news => news.NewsUrl))
                .Distinct()
                .ToListAsync();

            return urls.Distinct().ToDictionary(key => key, newsUrls.Contains);
        }

        public async Task<Entities.News?> FindNewsBySpecificationAsync(ISpecification<Entities.News> specification, 
            CancellationToken cancellationToken = default)
        {
            var query = _dbContext.News.AsNoTracking();

            if (specification.Includes is not null && specification.Includes.Count() > 0)
            {
                foreach (var include in specification.Includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.SingleOrDefaultAsync(specification.Criteria, cancellationToken);
        }
    }
}
