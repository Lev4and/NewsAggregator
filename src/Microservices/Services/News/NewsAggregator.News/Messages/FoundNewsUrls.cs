using MediatR;

namespace NewsAggregator.News.Messages
{
    public class FoundNewsUrls : INotification
    {
        public IReadOnlyCollection<string> NewsUrls { get; }

        public FoundNewsUrls(IReadOnlyCollection<string> newsUrls)
        {
            NewsUrls = newsUrls;
        }
    }
}
