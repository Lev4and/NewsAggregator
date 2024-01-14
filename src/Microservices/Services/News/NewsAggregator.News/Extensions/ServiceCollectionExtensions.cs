﻿using HtmlAgilityPack;
using MassTransit.Internals;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Domain.Infrastructure.Databases.Repositories;
using NewsAggregator.News.Databases.EntityFramework.News.Repositories;
using NewsAggregator.News.NewsSources;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Web.Http;

namespace NewsAggregator.News.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            foreach (var repositoryInterface in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                .Where(type => type.IsInterface && type.HasInterface(typeof(IRepository<>))))
            {
                foreach (var repository in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                    .Where(type => type.IsClass && type.HasInterface(repositoryInterface)))
                {
                    services.AddTransient(repositoryInterface, repository);
                }
            }

            services.AddTransient<IRepository, NewsDbRepository>();

            return services;
        }

        public static IServiceCollection AddNewsParsers(this IServiceCollection services) 
        {
            services.AddSingleton<Sources>();
            services.AddSingleton<HtmlWeb>();

            services.AddSingleton<NewsHttpClient>();

            services.AddSingleton<INewsParser, NewsHtmlAgilityPackParser>();
            services.AddSingleton<INewsUrlsParser, NewsUrlsHtmlAgilityPackParser>();

            return services;
        }
    }
}
