using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-viewed")]
    public class NewsViewed : INotification
    {
        public Guid NewsId { get; }

        public string IpAddress { get; }

        public DateTime ViewedAt { get; }

        public NewsViewed(Guid newsId, string ipAddress)
        {
            NewsId = newsId;
            IpAddress = ipAddress;
            ViewedAt = DateTime.UtcNow;
        }
    }
}
