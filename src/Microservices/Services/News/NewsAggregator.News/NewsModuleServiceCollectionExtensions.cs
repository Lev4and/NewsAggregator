using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsAggregator.Infrastructure.Extensions;
using NewsAggregator.News.ConfigurationOptions;
using NewsAggregator.News.Databases.EntityFramework.News;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.MessageConsumers;
using NewsAggregator.News.Messages;
using RabbitMQ.Client;
using System.Text.Json.Serialization;

namespace NewsAggregator.News
{
    public static class NewsModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddNewsModule(this IServiceCollection services, AppSettings settings)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<CheckAndRegisterNonExistentNewsConsumer>();
                busConfigurator.AddConsumer<AddNewsConsumer>();
                busConfigurator.AddConsumer<AddNewsParseErrorConsumer>();
                busConfigurator.AddConsumer<AddNewsParseNetworkErrorConsumer>();
                busConfigurator.AddConsumer<UnregisterNewsConsumer>();
                busConfigurator.AddConsumer<SendAddedNewsNotificationConsumer>();
                busConfigurator.AddConsumer<PrepareAddedNewsToIndexingConsumer>();
                busConfigurator.AddConsumer<IndexAddedNewsConsumer>();
                busConfigurator.AddConsumer<RegisterNewsViewConsumer>();
                busConfigurator.AddConsumer<RefreshNewsSourcesMemoryCacheConsumer>();
                busConfigurator.AddConsumer<RegisterNewsSiteVisitConsumer>();
                busConfigurator.AddConsumer<RegisterNewsReactionConsumer>();

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

                    configurator.Message<FoundNewsList>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.ReceiveEndpoint("check-and-register-non-existent-news", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news_list.found";
                        });

                        endpointConfigurator.Consumer<CheckAndRegisterNonExistentNewsConsumer>(context, configurator =>
                        {
                            configurator.UseConcurrencyLimit(1);
                        });
                    });

                    configurator.Send<RegisteredNewsForParse>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.registered");
                    });

                    configurator.Message<RegisteredNewsForParse>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<RegisteredNewsForParse>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = ExchangeType.Direct;
                    });

                    configurator.Message<ParsedNews>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.ReceiveEndpoint("add-news", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news.parsed";
                        });

                        endpointConfigurator.Consumer<AddNewsConsumer>(context, configurator =>
                        {
                            configurator.UseConcurrencyLimit(1);
                        });
                    });

                    configurator.Send<AddedNews>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.added");
                    });

                    configurator.Message<AddedNews>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<AddedNews>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = ExchangeType.Direct;
                    });

                    configurator.Send<ProcessedNews>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.processed");
                    });

                    configurator.Message<ProcessedNews>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<ProcessedNews>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = ExchangeType.Direct;
                    });

                    configurator.ReceiveEndpoint("unregister-news", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news.processed";
                        });

                        endpointConfigurator.Consumer<UnregisterNewsConsumer>(context);
                    });

                    configurator.Message<ThrowedExceptionWhenParseNews>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.ReceiveEndpoint("add-news-with-error-when-parse", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news.parsed_with_error";
                        });

                        endpointConfigurator.Consumer<AddNewsParseErrorConsumer>(context);
                    });

                    configurator.Message<ThrowedHttpRequestExceptionWhenParseNews>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.ReceiveEndpoint("add-news-with-network-error-when-parse", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news.parsed_with_network_error";
                        });

                        endpointConfigurator.Consumer<AddNewsParseNetworkErrorConsumer>(context);
                    });

                    configurator.ReceiveEndpoint("send-added-news-notification", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news.added";
                        });

                        endpointConfigurator.Consumer<SendAddedNewsNotificationConsumer>(context);
                    });

                    configurator.Send<AddedNewsNotificationGenerated>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.added.notification_generated");
                    });

                    configurator.Message<AddedNewsNotificationGenerated>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<AddedNewsNotificationGenerated>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = ExchangeType.Direct;
                    });

                    configurator.ReceiveEndpoint("prepare-added-news-to-indexing", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news.added";
                        });

                        endpointConfigurator.Consumer<PrepareAddedNewsToIndexingConsumer>(context);
                    });

                    configurator.Send<AddedNewsPreparedToIndexing>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.added.prepared_to_indexing");
                    });

                    configurator.Message<AddedNewsPreparedToIndexing>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<AddedNewsPreparedToIndexing>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = ExchangeType.Direct;
                    });

                    configurator.ReceiveEndpoint("index-added-news", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news.added.prepared_to_indexing";
                        });

                        endpointConfigurator.Consumer<IndexAddedNewsConsumer>(context);
                    });

                    configurator.Message<NewsViewed>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.ReceiveEndpoint("register-news-view", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news.viewed";
                        });

                        endpointConfigurator.Consumer<RegisterNewsViewConsumer>(context, configurator =>
                        {
                            configurator.UseConcurrencyLimit(1);
                        });
                    });

                    configurator.Message<NewsSourceListNotFound>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.ReceiveEndpoint("refresh-news-sources-memory-cache", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news_source_list.not_found";
                        });

                        endpointConfigurator.Consumer<RefreshNewsSourcesMemoryCacheConsumer>(context, configurator =>
                        {
                            configurator.UseConcurrencyLimit(1);
                        });
                    });

                    configurator.Message<NewsSiteVisited>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.ReceiveEndpoint("register-news-site-visit", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news_site.visited";
                        });

                        endpointConfigurator.Consumer<RegisterNewsSiteVisitConsumer>(context);
                    });

                    configurator.Message<NewsReacted>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.ReceiveEndpoint("register-news-reaction", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news.reacted";
                        });

                        endpointConfigurator.Consumer<RegisterNewsReactionConsumer>(context, configurator =>
                        {
                            configurator.UseConcurrencyLimit(1);
                        });
                    });
                });
            });

            services.AddRabbitMQMessageBus();

            services.AddNewsDbPostgreSql(settings.ConnectionStrings.NewsDbPostgreSql);
            services.AddNewsDbEntityFrameworkRepositories();
            services.AddNewsDbEntityFrameworkSearchers();

            services.AddNewsDbElasticsearch(settings.ConnectionStrings.NewsDbElasticsearch);
            services.AddNewsDbElasticsearchSearchers();

            services.AddNewsDbFakeIndexers();

            services.AddDefaultNewsSources();

            services.AddRedisMemoryCache(settings.Caching.Redis);
            services.AddNewsMemoryCache();

            services.AddCqrs();

            services.AddHttpClientNewsProviders();
            services.AddNewsAngleSharpParsers();

            return services;
        }

        public static void MigrateNewsDb(this IHost host)
        {
            using (var serviceScope = host.Services.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                serviceScope?.ServiceProvider.GetRequiredService<NewsDbContext>().Database.Migrate();
            }
        }
    }
}
