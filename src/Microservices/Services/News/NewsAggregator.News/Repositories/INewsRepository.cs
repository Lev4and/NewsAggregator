using AngleSharp.Dom;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.Domain.Specification;
using NewsAggregator.News.Specifications;

namespace NewsAggregator.News.Repositories
{
    public interface INewsRepository : IRepository<Entities.News>, IGridRepository<Entities.News>
    {
        Task<bool> ContainsNewsByUrlAsync(string url, CancellationToken cancellationToken = default);

        Task<IReadOnlyDictionary<string, bool>> ContainsNewsByUrlsAsync(IReadOnlyCollection<string> urls, 
            CancellationToken cancellationToken = default);

        Task<Entities.News?> FindNewsByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<Entities.News?> FindNewsByUrlAsync(string url, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<Entities.News>> FindRecentNewsAsync(int count, bool subTitleRequired = false,
            bool pictureRequired = false, CancellationToken cancellationToken = default);
    }
}
