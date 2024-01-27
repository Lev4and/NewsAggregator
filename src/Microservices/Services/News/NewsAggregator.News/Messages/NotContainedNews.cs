using MediatR;

namespace NewsAggregator.News.Messages
{
    public class NotContainedNews : INotification
    {
        public string NewsUrl { get; }

        public NotContainedNews(string newsUrl)
        {
            NewsUrl = newsUrl;
        }
    }
}
