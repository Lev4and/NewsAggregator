using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-source-list-not-found")]
    public class NewsSourceListNotFound : INotification
    {
        public NewsSourceListNotFound()
        {
            
        }
    }
}
