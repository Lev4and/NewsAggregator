using NewsAggregator.Infrastructure.MessageBrokers;

namespace NewsAggregator.Notification.ConfigurationOptions
{
    public class AppSettings
    {
        public MessageBrokerOptions MessageBroker { get; set; }
    }
}
