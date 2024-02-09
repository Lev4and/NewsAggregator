namespace NewsAggregator.Domain.Infrastructure.Caching
{
    public interface IMemoryCache
    {
        Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
            where T : class;

        Task<T> GetAsync<T>(string key, Func<Task<T>> factory, CancellationToken cancellationToken = default)
            where T : class;

        Task SetAsync<T>(string key,  T value, CancellationToken cancellationToken = default)
            where T : class;

        Task RemoveAsync(string key, CancellationToken cancellationToken = default);
    }
}
