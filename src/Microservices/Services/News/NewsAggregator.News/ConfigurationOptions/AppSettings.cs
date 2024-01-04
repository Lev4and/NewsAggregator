using NewsAggregator.Infrastructure.Caching;
using NewsAggregator.Infrastructure.MessageBrokers;
using NewsAggregator.News.Databases;

namespace NewsAggregator.News.ConfigurationOptions
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }

        public MessageBrokerOptions MessageBroker { get; set; }

        public CachingOptions Caching { get; set; }
    }
}
