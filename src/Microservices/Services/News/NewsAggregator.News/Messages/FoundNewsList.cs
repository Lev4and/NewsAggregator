using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-list-found")]
    public class FoundNewsList : INotification
    {
        public IReadOnlyCollection<string> NewsUrls { get; }

        public FoundNewsList(IReadOnlyCollection<string> newsUrls)
        {
            NewsUrls = newsUrls;
        }
    }
}
