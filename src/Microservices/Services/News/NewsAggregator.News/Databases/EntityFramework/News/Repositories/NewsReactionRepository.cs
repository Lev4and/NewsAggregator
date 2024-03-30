using Microsoft.EntityFrameworkCore;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.Databases.EntityFramework.News.Repositories
{
    public class NewsReactionRepository : NewsDbRepository<NewsReaction>, INewsReactionRepository
    {
        public NewsReactionRepository(NewsDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> ContainsAsync(Guid newsId, string ipAddress, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionAsync(reaction => reaction.NewsId == newsId 
                && reaction.IpAddress == ipAddress, cancellationToken) != null;
        }

        public async Task<IReadOnlyCollection<NewsReactionDto>> GetNewsReactionsByNewsIdAsync(Guid newsId, 
            CancellationToken cancellationToken = default)
        {
            return await _dbContext.Reactions.AsNoTracking()
                .Include(reaction => reaction.Icon)
                .Include(reaction => reaction.News)
                .Select(reaction => new NewsReactionDto
                {
                    NewsId = newsId,
                    ReactionId = reaction.Id,
                    ReactionTitle = reaction.Title,
                    ReactionIconClass = reaction.Icon.IconClass,
                    ReactionIconColor = reaction.Icon.IconColor,
                    Count = reaction.News.Where(news => news.NewsId == newsId).Count(),
                })
                .ToListAsync();
        }
    }
}
