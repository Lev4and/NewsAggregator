using NewsAggregator.Domain.Repositories;
using NewsAggregator.Domain.Specification;

namespace NewsAggregator.News.Repositories
{
    public interface INewsRepository : IRepository<Entities.News>, IGridRepository<Entities.News>
    {
        Task<bool> ContainsNewsByUrlAsync(string url, CancellationToken cancellationToken = default);

        Task<IReadOnlyDictionary<string, bool>> ContainsNewsByUrlsAsync(IReadOnlyCollection<string> urls, 
            CancellationToken cancellationToken = default);

        Task<Entities.News?> FindNewsBySpecificationAsync(ISpecification<Entities.News> specification, 
            CancellationToken cancellationToken = default);
    }
}
