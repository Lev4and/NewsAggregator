using MassTransit;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;

namespace NewsAggregator.Infrastructure.MessageBrokers.RabbitMQ
{
    public class RabbitMQMessageBus : IMessageBus
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public RabbitMQMessageBus(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendAsync<TMessage>(TMessage message, CancellationToken cancellationToken = default)
            where TMessage : class
        {
            await _publishEndpoint.Publish(message, cancellationToken);
        }
    }
}
