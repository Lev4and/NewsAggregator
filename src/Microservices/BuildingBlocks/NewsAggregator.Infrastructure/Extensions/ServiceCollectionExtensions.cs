using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.Infrastructure.Caching.Default;
using NewsAggregator.Infrastructure.Caching.Redis;
using NewsAggregator.Infrastructure.MessageBrokers.RabbitMQ;

namespace NewsAggregator.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMQMessageBus(this IServiceCollection services)
        {
            services.AddTransient<IMessageBus, RabbitMQMessageBus>();

            return services;
        }

        public static IServiceCollection AddElasticsearch(this IServiceCollection services, 
            ElasticsearchClientSettings settings) 
        {
            services.AddSingleton(factory => new ElasticsearchClient(settings));

            return services;
        }

        public static IServiceCollection AddRedisMemoryCache(this IServiceCollection services, RedisOptions options)
        {
            services.AddDistributedMemoryCache();

            services.AddSingleton<IMemoryCache, MemoryCache>();

            services.AddStackExchangeRedisCache(redisOptions =>
            {
                redisOptions.Configuration = options.ConnectionString;
            });

            return services;
        }
    }
}
