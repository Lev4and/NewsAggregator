using MediatR;

namespace NewsAggregator.News.Messages
{
    public class NotParsedNews : INotification
    {
        public string NewsUrl { get; }

        public DateTime CreatedAt { get; }

        public Exception Exception { get; }

        public NotParsedNews(string newsUrl, Exception exception)
        {
            NewsUrl = newsUrl;
            CreatedAt = DateTime.UtcNow;
            Exception = exception;
        }
    }
}
