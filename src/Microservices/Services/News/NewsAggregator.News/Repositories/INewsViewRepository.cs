using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Repositories
{
    public interface INewsViewRepository : IRepository<NewsView>
    {
        Task<bool> ContainsByNewsIdAndIpAddressAsync(Guid newsId, string ipAddress, 
            CancellationToken cancellationToken = default);

        Task<long> GetCountViewsByNewsIdAsync(Guid newsId, CancellationToken cancellationToken = default);
    }
}
