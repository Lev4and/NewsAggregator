using NewsAggregator.News.Entities;

namespace NewsAggregator.News.Caching
{
    public interface INewsEditorMemoryCache
    {
        Task<NewsEditor> GetNewsEditorByIdAsync(Guid id, Func<Task<NewsEditor>> factory,
            CancellationToken cancellationToken = default);
    }
}
