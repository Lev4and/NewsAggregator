using Microsoft.Extensions.Caching.Distributed;
using NewsAggregator.Domain.Infrastructure.Caching;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace NewsAggregator.Infrastructure.Caching.Default
{
    public class MemoryCache : IMemoryCache
    {
        private readonly IDistributedCache _distributedCache;

        public MemoryCache(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
            where T : class
        {
            var cachedValue = await _distributedCache.GetStringAsync(key, cancellationToken);

            return cachedValue != null
                ? JsonConvert.DeserializeObject<T>(cachedValue)
                : null;
        }

        public async Task<T> GetAsync<T>(string key, Func<Task<T>> factory, CancellationToken cancellationToken = default)
            where T : class
        {
            var cachedValue = await GetAsync<T>(key, cancellationToken) ?? await factory();

            await SetAsync(key, cachedValue, cancellationToken);

            return cachedValue;
        }

        public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default)
            where T : class
        {
            await _distributedCache.SetStringAsync(key, 
                JsonConvert.SerializeObject(value, 
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    }),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = new TimeSpan(365, 0, 0, 0)
                },
                cancellationToken);
        }

        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
            await _distributedCache.RemoveAsync(key, cancellationToken);
        }
    }
}
