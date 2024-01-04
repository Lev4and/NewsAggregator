using NewsAggregator.Infrastructure.MessageBrokers.RabbitMQ;

namespace NewsAggregator.Infrastructure.MessageBrokers
{
    public class MessageBrokerOptions
    {
        public RabbitMQOptions RabbitMQ { get; set; }
    }
}
