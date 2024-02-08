using MediatR;

namespace NewsAggregator.News.Messages
{
    public class ThrowedHttpRequestExceptionWhenParseNews : INotification
    {
        public string NewsUrl { get; }

        public string Message { get; }

        public DateTime CreatedAt { get; }

        public ThrowedHttpRequestExceptionWhenParseNews(string newsUrl, string message, DateTime createdAt)
        {
            NewsUrl = newsUrl;
            Message = message;
            CreatedAt = createdAt;
        }
    }
}
