using MediatR;

namespace NewsAggregator.News.Messages
{
    public class FoundNews : INotification
    {
        public string NewsUrl { get; }

        public FoundNews(string newsUrl)
        {
            NewsUrl = newsUrl;
        }
    }
}
