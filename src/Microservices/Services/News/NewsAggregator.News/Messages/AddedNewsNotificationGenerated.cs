using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-added-notification-generated")]
    public class AddedNewsNotificationGenerated : INotification
    {
        public Entities.News News { get; }

        public AddedNewsNotificationGenerated(Entities.News news)
        {
            News = news;
        }
    }
}
