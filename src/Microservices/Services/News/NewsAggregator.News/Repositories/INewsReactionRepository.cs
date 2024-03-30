using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Repositories
{
    public interface INewsReactionRepository : IRepository<NewsReaction>
    {
        Task<bool> ContainsAsync(Guid newsId, string ipAddress,
            CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<NewsReactionDto>> GetNewsReactionsByNewsIdAsync(Guid newsId,
            CancellationToken cancellationToken = default);
    }
}
