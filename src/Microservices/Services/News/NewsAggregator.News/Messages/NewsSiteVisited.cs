using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-site-visited")]
    public class NewsSiteVisited : INotification
    {
        public string IpAddress { get; }

        public DateTime VisitedAt { get; }

        public NewsSiteVisited(string ipAddress)
        {
            IpAddress = ipAddress;
            VisitedAt = DateTime.UtcNow;
        }
    }
}
