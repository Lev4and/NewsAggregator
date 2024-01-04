﻿
using Microsoft.EntityFrameworkCore;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public class NewsRepository : NewsDbRepository<Entities.News>, INewsRepository
    {
        public NewsRepository(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> ContainsNewsByUrlAsync(string url, CancellationToken cancellationToken = default)
        {
            return await FindNewsByUrlAsync(url, cancellationToken) != null;
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
