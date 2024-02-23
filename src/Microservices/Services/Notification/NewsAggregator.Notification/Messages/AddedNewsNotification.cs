using MassTransit;
using MediatR;
using NewsAggregator.Notification.DTOs;

namespace NewsAggregator.Notification.Messages
{
    [MessageUrn("news-added-notification-generated")]
    public class AddedNewsNotification : INotification
    {
        public News News { get; }

        public AddedNewsNotification(News news)
        {
            News = news;
        }
    }
}
