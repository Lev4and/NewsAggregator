namespace NewsAggregator.Infrastructure.MessageBrokers.RabbitMQ
{
    public class RabbitMQOptions
    {
        public string Host { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
