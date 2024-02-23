using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-added")]
    public class AddedNews : INotification
    {
        public Entities.News News { get; }

        public AddedNews(Entities.News news)
        {
            News = news;
        }
    }
}
