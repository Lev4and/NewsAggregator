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
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.MessageConsumers;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Pipelines;
using NewsAggregator.News.UseCases.Commands;
using System.Text.Json.Serialization;

namespace NewsAggregator.News
{
    public static class ParserNewsModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddParserNewsModule(this IServiceCollection services, AppSettings settings)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<RegisteredNewsForParseMessageConsumer>();

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

                    configurator.ReceiveEndpoint("parse-news", endpointConfugurator =>
                    {
                        endpointConfugurator.Bind("news.events",
                            exchangeConfigurator =>
                            {
                                endpointConfugurator.Durable = true;
                                endpointConfugurator.ExchangeType = "direct";
                                exchangeConfigurator.RoutingKey = "news.registered";
                            });
                    });

                    configurator.Send<ParsedNews>(configurator =>
                        configurator.UseRoutingKeyFormatter(formatter =>
                            "news.parsed"));

                    configurator.Message<ParsedNews>(configurator =>
                        configurator.SetEntityName("news.events"));

                    configurator.Send<ThrowedExceptionWhenParseNews>(configurator =>
                        configurator.UseRoutingKeyFormatter(formatter =>
                            "news.parsed.with.error"));

                    configurator.Message<ThrowedExceptionWhenParseNews>(configurator =>
                        configurator.SetEntityName("news.events"));

                    configurator.Send<ThrowedHttpRequestExceptionWhenParseNews>(configurator =>
                        configurator.UseRoutingKeyFormatter(formatter =>
                            "news.parsed.with.network.error"));

                    configurator.Message<ThrowedHttpRequestExceptionWhenParseNews>(configurator =>
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

            services.AddScoped<IRequestHandler<ParseNewsCommand, NewsDto>, ParseNewsCommand.Handler>();

            services.AddScoped<INotificationHandler<ParsedNews>, 
                ParseNewsCommand.ParsedNewsNotificationHandler>();

            services.AddScoped<INotificationHandler<ThrowedExceptionWhenParseNews>, 
                ParseNewsCommand.ThrowedExceptionWhenParseNewsNotificationHandler>();

            services.AddScoped<INotificationHandler<ThrowedHttpRequestExceptionWhenParseNews>, 
                ParseNewsCommand.ThrowedHttpRequestExceptionWhenParseNewsNotificationHandler>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            services.AddHttpClientNewsProviders();
            services.AddNewsAngleSharpParsers();

            return services;
        }
    }
}
