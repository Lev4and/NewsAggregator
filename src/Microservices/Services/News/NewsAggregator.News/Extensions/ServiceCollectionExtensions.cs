using AngleSharp.Html.Parser;
using Elastic.Clients.Elasticsearch;
using FluentValidation;
using MassTransit.Internals;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Domain.Indexers;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.Domain.Searchers;
using NewsAggregator.Infrastructure.Databases.Elasticsearch.Repositories;
using NewsAggregator.Infrastructure.Databases.Elasticsearch.Searchers;
using NewsAggregator.Infrastructure.Databases.EntityFramework.Repositories;
using NewsAggregator.Infrastructure.Databases.EntityFramework.Searchers;
using NewsAggregator.Infrastructure.Extensions;
using NewsAggregator.News.Caching;
using NewsAggregator.News.Databases.Elasticsearch.News.Indexers;
using NewsAggregator.News.Databases.Elasticsearch.News.Repositories;
using NewsAggregator.News.Databases.Elasticsearch.News.Searchers;
using NewsAggregator.News.Databases.EntityFramework.News;
using NewsAggregator.News.Databases.EntityFramework.News.Repositories;
using NewsAggregator.News.Databases.EntityFramework.News.Searchers;
using NewsAggregator.News.Databases.Fake.News.Indexers;
using NewsAggregator.News.NewsSources;
using NewsAggregator.News.Pipelines;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;
using NewsAggregator.News.Web.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.Reflection;

namespace NewsAggregator.News.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNewsDbPostgreSql(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NewsDbContext>((options) =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUnitOfWork>(serviceProvider => 
                serviceProvider.GetRequiredService<NewsDbContext>());

            return services;
        }

        public static IServiceCollection AddNewsDbEntityFrameworkRepositories(this IServiceCollection services)
        {
            foreach (var repositoryInterface in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                .Where(type => type.IsInterface && type.HasInterface(typeof(IRepository<>))))
            {
                foreach (var repository in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                    .Where(type => type.IsClass && type.HasInterface(repositoryInterface)
                        && type.HasInterface(typeof(IEntityFrameworkRepository<>))))
                {
                    services.AddTransient(repositoryInterface, repository);
                }
            }

            services.AddTransient<IRepository, NewsDbEntityFrameworkRepository>();

            return services;
        }

        public static IServiceCollection AddNewsDbEntityFrameworkSearchers(this IServiceCollection services) 
        {
            foreach (var repositoryInterface in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                .Where(type => type.IsInterface && type.HasInterface(typeof(ISearcher<>))))
            {
                foreach (var repository in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                    .Where(type => type.IsClass && type.HasInterface(repositoryInterface)
                        && type.HasInterface(typeof(IEntityFrameworkSearcher<>))))
                {
                    services.AddTransient(repositoryInterface, repository);
                }
            }

            services.AddTransient<ISearcher, NewsDbEntityFrameworkSearcher>();

            return services;
        }

        public static IServiceCollection AddNewsDbElasticsearch(this IServiceCollection services, string connectionString)
        {
            var settings = new ElasticsearchClientSettings(new Uri(connectionString))
                .DefaultMappingFor<Entities.News>(selector => selector
                    .IndexName("news")
                        .IdProperty(property => property.Id))
                .EnableDebugMode();

            return services.AddElasticsearch(settings);
        }

        public static IServiceCollection AddNewsDbElasticsearchIndexers(this IServiceCollection services)
        {
            services.AddSingleton<IIndexer, NewsDbElasticsearchIndexer>();

            return services;
        }

        public static IServiceCollection AddNewsDbElasticsearchRepositories(this IServiceCollection services)
        {
            foreach (var repositoryInterface in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                .Where(type => type.IsInterface && type.HasInterface(typeof(IRepository<>))))
            {
                foreach (var repository in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                    .Where(type => type.IsClass && type.HasInterface(repositoryInterface) 
                        && type.HasInterface(typeof(IElasticsearchRepository<>))))
                {
                    services.AddTransient(repositoryInterface, repository);
                }
            }

            services.AddTransient<IRepository, NewsDbElasticsearchRepository>();

            return services;
        }

        public static IServiceCollection AddNewsDbElasticsearchSearchers(this IServiceCollection services)
        {
            foreach (var repositoryInterface in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                .Where(type => type.IsInterface && type.HasInterface(typeof(ISearcher<>))))
            {
                foreach (var repository in typeof(ServiceCollectionExtensions).Assembly.GetTypes()
                    .Where(type => type.IsClass && type.HasInterface(repositoryInterface)
                        && type.HasInterface(typeof(IElasticsearchSearcher<>))))
                {
                    services.AddTransient(repositoryInterface, repository);
                }
            }

            services.AddTransient<ISearcher, NewsDbElasticsearchSearcher>();

            return services;
        }

        public static IServiceCollection AddNewsDbFakeIndexers(this IServiceCollection services)
        {
            services.AddSingleton<IIndexer, NewsDbFakeIndexer>();

            return services;
        }

        public static IServiceCollection AddNewsMemoryCache(this IServiceCollection services)
        {
            services.AddSingleton<INewsMemoryCache, NewsMemoryCache>();
            services.AddSingleton<INewsEditorMemoryCache, NewsEditorMemoryCache>();
            services.AddSingleton<INewsSourceMemoryCache, NewsSourceMemoryCache>();

            return services;
        }

        public static IServiceCollection AddCqrs(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            return services;
        }

        public static IServiceCollection AddDefaultNewsSources(this IServiceCollection services)
        {
            services.AddSingleton<Sources>();

            return services;
        }

        public static IServiceCollection AddHttpClientNewsProviders(this IServiceCollection services)
        {
            services.AddSingleton<NewsHttpClient>();

            services.AddScoped<INewsHtmlPageProvider, HttpClientNewsHtmlPageProvider>();
            services.AddScoped<INewsListHtmlPageProvider, HttpClientNewsListHtmlPageProvider>();

            return services;
        }

        public static IServiceCollection AddSeleniumNewsProviders(this IServiceCollection services, Uri seleniumHubRemoteUrl, 
            DriverOptions driverOptions) 
        {
            services.AddScoped<IWebDriver, RemoteWebDriver>(factory => 
                new RemoteWebDriver(seleniumHubRemoteUrl, driverOptions));

            services.AddScoped<INewsHtmlPageProvider, SeleniumNewsHtmlPageProvider>();
            services.AddScoped<INewsListHtmlPageProvider, SeleniumNewsListHtmlPageProvider>();

            return services;
        }

        public static IServiceCollection AddNewsAngleSharpParsers(this IServiceCollection services) 
        {
            services.AddScoped<HtmlParser>();

            services.AddScoped<INewsParser, NewsAngleSharpParser>();
            services.AddScoped<INewsUrlsParser, NewsUrlsAngleSharpParser>();

            return services;
        }

        public static IServiceCollection AddNewsHtmlAgilityPackParsers(this IServiceCollection services)
        {
            services.AddScoped<INewsParser, NewsHtmlAgilityPackParser>();
            services.AddScoped<INewsUrlsParser, NewsUrlsHtmlAgilityPackParser>();

            return services;
        }
    }
}
