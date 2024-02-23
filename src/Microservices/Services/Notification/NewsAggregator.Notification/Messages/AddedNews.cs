using MassTransit;
using MediatR;
using NewsAggregator.Notification.DTOs;

namespace NewsAggregator.Notification.Messages
{
    [MessageUrn("news-added")]
    public class AddedNews : INotification
    {
        public News News { get; }

        public AddedNews(News news)
        {
            News = news;
        }
    }
}
