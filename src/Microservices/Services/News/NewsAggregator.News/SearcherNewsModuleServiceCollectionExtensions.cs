﻿using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Domain.Infrastructure.Caching;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.Infrastructure.Caching.Default;
using NewsAggregator.Infrastructure.MessageBrokers.RabbitMQ;
using NewsAggregator.News.Caching;
using NewsAggregator.News.ConfigurationOptions;
using NewsAggregator.News.Databases.EntityFramework.News;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.HostedServices;
using NewsAggregator.News.Pipelines;
using System.Reflection;

namespace NewsAggregator.News
{
    public static class SearcherNewsModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddSearcherNewsModule(this IServiceCollection services, AppSettings settings)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.SetKebabCaseEndpointNameFormatter();

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

            services.AddNewsParsers();

            services.AddHostedService<SearchingNewsWorker>();

            return services;
        }
    }
}
