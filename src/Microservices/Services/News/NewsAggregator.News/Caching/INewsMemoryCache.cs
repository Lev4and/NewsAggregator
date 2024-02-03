namespace NewsAggregator.News.Caching
{
    public interface INewsMemoryCache
    {
        Task<Entities.News> GetNewsByIdAsync(Guid id, Func<Task<Entities.News>> factory, 
            CancellationToken cancellationToken = default);
    }
}
