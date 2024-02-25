using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("added-news-prepared-to-indexing")]
    public class AddedNewsPreparedToIndexing : INotification
    {
        public Entities.News News { get; }

        public AddedNewsPreparedToIndexing(Entities.News news)
        {
            News = news;
        }
    }
}
