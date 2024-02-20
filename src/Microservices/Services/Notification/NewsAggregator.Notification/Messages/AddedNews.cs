using MediatR;
using NewsAggregator.Notification.DTOs;

namespace NewsAggregator.Notification.Messages
{
    public class AddedNews : INotification
    {
        public News News { get; }

        public AddedNews(News news)
        {
            News = news;
        }
    }
}
