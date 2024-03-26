using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Infrastructure.Extensions;
using NewsAggregator.News.ConfigurationOptions;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.Messages;
using RabbitMQ.Client;
using System.Text.Json.Serialization;

namespace NewsAggregator.News
{
    public static class MvcNewsModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddMvcNewsModule(this IServiceCollection services, AppSettings settings)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(settings.MessageBroker.RabbitMQ.Host), hostConfigurator =>
                    {
                        hostConfigurator.Username(settings.MessageBroker.RabbitMQ.Username);
                        hostConfigurator.Password(settings.MessageBroker.RabbitMQ.Password);
                    });

                    configurator.UseRawJsonDeserializer(RawSerializerOptions.AnyMessageType);

                    configurator.ConfigureJsonSerializerOptions(options =>
                    {
                        options.ReferenceHandler = ReferenceHandler.IgnoreCycles;

                        return options;
                    });

                    configurator.Send<NewsViewed>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.viewed");
                    });

                    configurator.Message<NewsViewed>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<NewsViewed>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = ExchangeType.Direct;
                    });

                    configurator.Send<NewsSiteVisited>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news_site.visited");
                    });

                    configurator.Message<NewsSiteVisited>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<NewsSiteVisited>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = ExchangeType.Direct;
                    });
                });
            });

            services.AddRabbitMQMessageBus();

            services.AddNewsDbPostgreSql(settings.ConnectionStrings.NewsDbPostgreSql);
            services.AddNewsDbEntityFrameworkRepositories();

            services.AddNewsDbElasticsearch(settings.ConnectionStrings.NewsDbElasticsearch);
            services.AddNewsDbElasticsearchSearchers();

            services.AddNewsDbFakeIndexers();

            services.AddRedisMemoryCache(settings.Caching.Redis);
            services.AddNewsMemoryCache();

            services.AddCqrs();

            services.AddHttpClientNewsProviders();
            services.AddNewsAngleSharpParsers();

            return services;
        }
    }
}
