using MediatR;

namespace NewsAggregator.News.Messages
{
    public class FoundNewsList : INotification
    {
        public IReadOnlyCollection<string> NewsUrls { get; }

        public FoundNewsList(IReadOnlyCollection<string> newsUrls)
        {
            NewsUrls = newsUrls;
        }
    }
}
