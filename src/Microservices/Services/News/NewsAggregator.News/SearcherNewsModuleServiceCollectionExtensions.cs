using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Infrastructure.Extensions;
using NewsAggregator.News.ConfigurationOptions;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.HostedServices;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Pipelines;
using NewsAggregator.News.UseCases.Commands;
using NewsAggregator.News.UseCases.Queries;
using RabbitMQ.Client;
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

                    configurator.UseRawJsonDeserializer(RawSerializerOptions.AnyMessageType);

                    configurator.ConfigureJsonSerializerOptions(options =>
                    {
                        options.ReferenceHandler = ReferenceHandler.IgnoreCycles;

                        return options;
                    });

                    configurator.Send<FoundNewsList>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news_list.found");
                    });

                    configurator.Message<FoundNewsList>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<FoundNewsList>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = ExchangeType.Direct;
                    });
                });
            });

            services.AddRabbitMQMessageBus();

            services.AddRedisMemoryCache(settings.Caching.Redis);
            services.AddNewsMemoryCache();

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
