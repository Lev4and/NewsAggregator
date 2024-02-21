﻿using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.Infrastructure.MessageBrokers.RabbitMQ;
using NewsAggregator.Notification.ConfigurationOptions;
using NewsAggregator.Notification.MessageConsumers;
using NewsAggregator.Notification.Messages;
using NewsAggregator.Notification.Pipelines;
using System.Reflection;
using System.Text.Json.Serialization;

namespace NewsAggregator.Notification
{
    public static class NotificationModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddNotificationModule(this IServiceCollection services, AppSettings settings)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer <AddedNewsMessageConsumer>();

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

                    configurator.ReceiveEndpoint("send-websocket-added-news-notification", endpointConfugurator =>
                    {
                        endpointConfugurator.Bind("news.events",
                            exchangeConfigurator =>
                            {
                                endpointConfugurator.Durable = true;
                                endpointConfugurator.ExchangeType = "direct";
                                exchangeConfigurator.RoutingKey = "news.added";
                            });

                        endpointConfugurator.Bind<AddedNews>();
                    });
                });
            });

            services.AddTransient<IMessageBus, RabbitMQMessageBus>();

            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));

            return services;
        }
    }
}
