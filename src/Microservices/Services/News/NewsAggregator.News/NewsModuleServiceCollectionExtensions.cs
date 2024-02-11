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
using NewsAggregator.News.Pipelines;
using NewsAggregator.News.Repositories;
using System.Reflection;

namespace NewsAggregator.News
{
    public static class NewsModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddNewsModule(this IServiceCollection services, AppSettings settings)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

                busConfigurator.AddConsumer<AddedNewsMessageConsumer>();
                busConfigurator.AddConsumer<FoundNewsListMessageConsumer>();
                busConfigurator.AddConsumer<FoundNotExistedNewsMessageConsumer>();
                busConfigurator.AddConsumer<ParsedNewsMessageConsumer>();
                busConfigurator.AddConsumer<ThrowedExceptionWhenParseNewsMessageConsumer>();
                busConfigurator.AddConsumer<ThrowedHttpRequestExceptionWhenParseNewsMessageConsumer>();

                busConfigurator.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(new Uri(settings.MessageBroker.RabbitMQ.Host), hostConfigurator =>
                    {
                        hostConfigurator.Username(settings.MessageBroker.RabbitMQ.Username);
                        hostConfigurator.Password(settings.MessageBroker.RabbitMQ.Password);
                    });

                    configurator.ConfigureEndpoints(context);
                });
            });

            services.AddTransient<IMessageBus, RabbitMQMessageBus>();

            services.AddDbContext<NewsDbContext>((options) =>
            {
                options.UseNpgsql(settings.ConnectionStrings.NewsDbPostgreSql)
                    .UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<NewsDbContext>());

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

            services.AddSeleniumNewsProviders();
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
