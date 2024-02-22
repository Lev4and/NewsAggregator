using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.Infrastructure.Caching.Default;
using NewsAggregator.Infrastructure.MessageBrokers.RabbitMQ;
using NewsAggregator.News.Caching;
using NewsAggregator.News.ConfigurationOptions;
using NewsAggregator.News.Databases.EntityFramework.News;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.MessageConsumers;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Pipelines;
using NewsAggregator.News.Repositories;
using System.Reflection;
using System.Text.Json.Serialization;
using static MassTransit.MessageHeaders;

namespace NewsAggregator.News
{
    public static class NewsModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddNewsModule(this IServiceCollection services, AppSettings settings)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<FoundNewsListMessageConsumer>();
                busConfigurator.AddConsumer<FoundNotExistedNewsMessageConsumer>();
                busConfigurator.AddConsumer<ParsedNewsMessageConsumer>();
                busConfigurator.AddConsumer<AddedNewsMessageConsumer>();
                busConfigurator.AddConsumer<ThrowedExceptionWhenParseNewsMessageConsumer>();
                busConfigurator.AddConsumer<ThrowedHttpRequestExceptionWhenParseNewsMessageConsumer>();

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(settings.MessageBroker.RabbitMQ.Host), hostConfigurator =>
                    {
                        hostConfigurator.Username(settings.MessageBroker.RabbitMQ.Username);
                        hostConfigurator.Password(settings.MessageBroker.RabbitMQ.Password);
                    });

                    configurator.ConfigureJsonSerializerOptions(options =>
                    {
                        options.ReferenceHandler = ReferenceHandler.IgnoreCycles;

                        return options;
                    });

                    configurator.Message<FoundNewsList>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.ReceiveEndpoint("contains-news-by-urls", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = "direct";
                            exchangeBindingConfigurator.RoutingKey = "news.list.found";
                        });

                        endpointConfigurator.Consumer<FoundNewsListMessageConsumer>(context);
                    });

                    configurator.Send<FoundNotExistedNews>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.found");
                    });

                    configurator.Message<FoundNotExistedNews>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<FoundNotExistedNews>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = "direct";
                    });

                    configurator.ReceiveEndpoint("register-news", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = "direct";
                            exchangeBindingConfigurator.RoutingKey = "news.found";
                        });

                        endpointConfigurator.Consumer<FoundNotExistedNewsMessageConsumer>(context);
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
                        messagePublishConfigurator.ExchangeType = "direct";
                    });

                    configurator.Send<ParsedNews>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.parsed");
                    });

                    configurator.Message<ParsedNews>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<ParsedNews>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = "direct";
                    });

                    configurator.ReceiveEndpoint("add-news", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = "direct";
                            exchangeBindingConfigurator.RoutingKey = "news.parsed";
                        });

                        endpointConfigurator.Consumer<ParsedNewsMessageConsumer>(context);
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
                        messagePublishConfigurator.ExchangeType = "direct";
                    });

                    configurator.ReceiveEndpoint("unregister-news", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = "direct";
                            exchangeBindingConfigurator.RoutingKey = "news.added";
                        });

                        endpointConfigurator.Consumer<AddedNewsMessageConsumer>(context);
                    });

                    configurator.Send<ThrowedExceptionWhenParseNews>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.parsed.with.error");
                    });

                    configurator.Message<ThrowedExceptionWhenParseNews>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<ThrowedExceptionWhenParseNews>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = "direct";
                    });

                    configurator.ReceiveEndpoint("add-news-with-error-when-parse", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = "direct";
                            exchangeBindingConfigurator.RoutingKey = "news.parsed.with.error";
                        });

                        endpointConfigurator.Consumer<ThrowedExceptionWhenParseNewsMessageConsumer>(context);
                    });

                    configurator.Send<ThrowedHttpRequestExceptionWhenParseNews>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.parsed.with.network.error");
                    });

                    configurator.Message<ThrowedHttpRequestExceptionWhenParseNews>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<ThrowedHttpRequestExceptionWhenParseNews>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = "direct";
                    });

                    configurator.ReceiveEndpoint("add-news-with-network-error-when-parse", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = "direct";
                            exchangeBindingConfigurator.RoutingKey = "news.parsed.with.network.error";
                        });

                        endpointConfigurator.Consumer<ThrowedHttpRequestExceptionWhenParseNewsMessageConsumer>(context);
                    });
                });
            });

            services.AddTransient<IMessageBus, RabbitMQMessageBus>();

            services.AddDbContext<NewsDbContext>((options) =>
            {
                options.UseNpgsql(settings.ConnectionStrings.NewsDbPostgreSql)
                    .UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<NewsDbContext>());

            services.AddDefaultNewsSources();
            services.AddRepositories();

            services.AddDistributedMemoryCache();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<INewsMemoryCache, NewsMemoryCache>();
            services.AddSingleton<INewsEditorMemoryCache, NewsEditorMemoryCache>();
            services.AddSingleton<INewsSourceMemoryCache, NewsSourceMemoryCache>();

            services.AddStackExchangeRedisCache(redisOptions =>
            {
                redisOptions.Configuration = settings.Caching.Redis.ConnectionString;
            });

            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

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

        public static async Task RefreshNewsSourceMemoryCacheAsync(this IHost host)
        {
            using (var serviceScope = host.Services.GetService<IServiceScopeFactory>()?.CreateScope())
            {
                var memoryCache = serviceScope?.ServiceProvider.GetRequiredService<INewsSourceMemoryCache>();
                var newsSourceRepository = serviceScope?.ServiceProvider.GetRequiredService<INewsSourceRepository>();

                if (memoryCache is not null && newsSourceRepository is not null)
                {
                    var newsSources = await newsSourceRepository.FindAvailableNewsSourcesExtendedAsync();

                    await memoryCache.RemoveAvailableNewsSourcesAsync();

                    foreach (var newsSource in newsSources)
                    {
                        await memoryCache.RemoveNewsSourceByIdAsync(newsSource.Id);

                        await memoryCache.RemoveNewsSourceBySiteUrlAsync(newsSource.SiteUrl);

                        await memoryCache.GetNewsSourceByIdAsync(newsSource.Id,
                            () => Task.FromResult(newsSource));

                        await memoryCache.GetNewsSourceBySiteUrlAsync(newsSource.SiteUrl,
                            () => Task.FromResult(newsSource));
                    }

                    await memoryCache.GetAvailableNewsSourcesAsync(() => Task.FromResult(newsSources));
                }
            }
        }
    }
}
