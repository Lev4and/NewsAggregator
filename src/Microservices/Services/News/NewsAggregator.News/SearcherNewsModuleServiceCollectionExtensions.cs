using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.Infrastructure.Caching.Default;
using NewsAggregator.Infrastructure.MessageBrokers.RabbitMQ;
using NewsAggregator.News.Caching;
using NewsAggregator.News.ConfigurationOptions;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.HostedServices;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Pipelines;
using NewsAggregator.News.UseCases.Commands;
using NewsAggregator.News.UseCases.Queries;
using System.Reflection;
using System.Text.Json.Serialization;

namespace NewsAggregator.News
{
    public static class SearcherNewsModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddSearcherNewsModule(this IServiceCollection services, AppSettings settings)
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

                    configurator.ConfigureJsonSerializerOptions(options =>
                    {
                        options.ReferenceHandler = ReferenceHandler.IgnoreCycles;

                        return options;
                    });

                    configurator.Send<FoundNewsList>(configurator =>
                        configurator.UseRoutingKeyFormatter(formatter =>
                            "news.list.found"));

                    configurator.Message<FoundNewsList>(configurator =>
                        configurator.SetEntityName("news.events"));
                });
            });

            services.AddTransient<IMessageBus, RabbitMQMessageBus>();

            services.AddDistributedMemoryCache();
            services.AddSingleton<IMemoryCache, MemoryCache>();
            services.AddSingleton<INewsSourceMemoryCache, NewsSourceMemoryCache>();

            services.AddStackExchangeRedisCache(redisOptions =>
            {
                redisOptions.Configuration = settings.Caching.Redis.ConnectionString;
            });

            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(IMediator).Assembly));

            services.AddScoped<IRequestHandler<GetAvailableNewsSourcesQuery, IReadOnlyCollection<NewsSource>>, 
                GetAvailableNewsSourcesQuery.Handler>();

            services.AddScoped<IRequestHandler<SearchNewsByNewsSourceCommand, IReadOnlyCollection<string>>, 
                SearchNewsByNewsSourceCommand.Handler>();

            services.AddScoped<INotificationHandler<FoundNewsList>, 
                SearchNewsByNewsSourceCommand.FoundNewsListNotificationHandler>();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            services.AddHttpClientNewsProviders();
            services.AddNewsAngleSharpParsers();

            services.AddHostedService<SearchingNewsWorker>();

            return services;
        }
    }
}
