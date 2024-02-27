using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("list-non-existent-news-formed")]
    public class ListNonExistentNewsFormed : INotification
    {
        public IReadOnlyCollection<string> NewsUrls { get; }

        public ListNonExistentNewsFormed(IReadOnlyCollection<string> newsUrls)
        {
            NewsUrls = newsUrls;
        }
    }
}
