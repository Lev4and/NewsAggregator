using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using MassTransit.Internals;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Domain.Repositories;
using NewsAggregator.News.Databases.EntityFramework.News.Repositories;
using NewsAggregator.News.NewsSources;
using NewsAggregator.News.Services.Parsers;
using NewsAggregator.News.Services.Providers;
using NewsAggregator.News.Web.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

        public static IServiceCollection AddSeleniumNewsProviders(this IServiceCollection services) 
        {
            services.AddSingleton<Sources>();

            services.AddScoped<IWebDriver, ChromeDriver>();

            services.AddScoped<INewsHtmlPageProvider, SeleniumNewsHtmlPageProvider>();
            services.AddScoped<INewsListHtmlPageProvider, SeleniumNewsListHtmlPageProvider>();

            return services;
        }

        public static IServiceCollection AddHttpClientNewsProviders(this IServiceCollection services)
        {
            services.AddSingleton<Sources>();

            services.AddSingleton<NewsHttpClient>();

            services.AddScoped<INewsHtmlPageProvider, HttpClientNewsHtmlPageProvider>();
            services.AddScoped<INewsListHtmlPageProvider, HttpClientNewsListHtmlPageProvider>();

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
