using MediatR;

namespace NewsAggregator.News.Messages
{
    public class FoundNotExistedNews : INotification
    {
        public string NewsUrl { get; }

        public FoundNotExistedNews(string newsUrl)
        {
            NewsUrl = newsUrl;
        }
    }
}
