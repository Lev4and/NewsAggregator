using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using NewsAggregator.Infrastructure.Extensions;
using NewsAggregator.Notification.ConfigurationOptions;
using NewsAggregator.Notification.Extensions;
using NewsAggregator.Notification.MessageConsumers;
using NewsAggregator.Notification.Messages;
using RabbitMQ.Client;
using System.Text.Json.Serialization;

namespace NewsAggregator.Notification
{
    public static class NotificationModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddNotificationModule(this IServiceCollection services, AppSettings settings)
        {
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumer<SendByWebsocketAddedNewsNotificationConsumer>();

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

                    configurator.Message<AddedNewsNotification>(messageConfigurator =>
                    {
                        messageConfigurator.SetEntityName("news.events");
                    });

                    configurator.ReceiveEndpoint("send-by-websocket-added-news-notification", endpointConfigurator =>
                    {
                        endpointConfigurator.Durable = true;
                        endpointConfigurator.ConfigureConsumeTopology = false;

                        endpointConfigurator.Bind("news.events", exchangeBindingConfigurator =>
                        {
                            exchangeBindingConfigurator.ExchangeType = ExchangeType.Direct;
                            exchangeBindingConfigurator.RoutingKey = "news.added.notification_generated";
                        });

                        endpointConfigurator.Consumer<SendByWebsocketAddedNewsNotificationConsumer>(context);
                    });
                });
            });

            services.AddRabbitMQMessageBus();

            services.AddCqrs();

            return services;
        }
    }
}
