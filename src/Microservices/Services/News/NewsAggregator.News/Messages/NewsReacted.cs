using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-reacted")]
    public class NewsReacted : INotification
    {
        public Guid NewsId { get; }

        public Guid ReactionId { get; }

        public string IpAddress { get; }

        public DateTime ReactedAt { get; }

        public NewsReacted(Guid newsId, Guid reactionId, string ipAddress)
        {
            NewsId = newsId;
            ReactionId = reactionId;
            IpAddress = ipAddress;
            ReactedAt = DateTime.UtcNow;

        }
    }
}
