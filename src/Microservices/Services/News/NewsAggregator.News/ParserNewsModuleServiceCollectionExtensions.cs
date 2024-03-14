using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Infrastructure.Extensions;
using NewsAggregator.News.ConfigurationOptions;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.MessageConsumers;
using NewsAggregator.News.Messages;
using NewsAggregator.News.Pipelines;
using NewsAggregator.News.UseCases.Commands;
using OpenQA.Selenium.Chrome;
using RabbitMQ.Client;
using System.Text.Json.Serialization;

namespace NewsAggregator.News
{
    public static class ParserNewsModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddParserNewsModule(this IServiceCollection services, AppSettings settings)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<ParseNewsConsumer>();

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

                    configurator.Message<RegisteredNewsForParse>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.ReceiveEndpoint("parse-news", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news.registered";
                        });

                        endpointConfigurator.Consumer<ParseNewsConsumer>(context, configurator =>
                        {
                            configurator.UseConcurrencyLimit(1);
                        });
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
                        messagePublishConfigurator.ExchangeType = ExchangeType.Direct;
                    });

                    configurator.Send<ThrowedExceptionWhenParseNews>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.parsed_with_error");
                    });

                    configurator.Message<ThrowedExceptionWhenParseNews>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<ThrowedExceptionWhenParseNews>(messagePublishConfigurator =>
                    {
                        messagePublishConfigurator.Durable = true;
                        messagePublishConfigurator.ExchangeType = ExchangeType.Direct;
                    });

                    configurator.Send<ThrowedHttpRequestExceptionWhenParseNews>(messageSendConfigurator =>
                    {
                        messageSendConfigurator.UseRoutingKeyFormatter(context => "news.parsed_with_network_error");
                    });

                    configurator.Message<ThrowedHttpRequestExceptionWhenParseNews>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.Publish<ThrowedHttpRequestExceptionWhenParseNews>(messagePublishConfigurator =>
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

            services.AddScoped<IRequestHandler<ParseNewsCommand, NewsDto>, ParseNewsCommand.Handler>();

            services.AddScoped<INotificationHandler<ParsedNews>, 
                ParseNewsCommand.ParsedNewsNotificationHandler>();

            services.AddScoped<INotificationHandler<ThrowedExceptionWhenParseNews>, 
                ParseNewsCommand.ThrowedExceptionWhenParseNewsNotificationHandler>();

            services.AddScoped<INotificationHandler<ThrowedHttpRequestExceptionWhenParseNews>, 
                ParseNewsCommand.ThrowedHttpRequestExceptionWhenParseNewsNotificationHandler>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            services.AddSeleniumNewsProviders(new Uri(settings.WebScraping.Selenium.ConnectionString),
                new ChromeOptions());

            services.AddNewsAngleSharpParsers();

            return services;
        }
    }
}
