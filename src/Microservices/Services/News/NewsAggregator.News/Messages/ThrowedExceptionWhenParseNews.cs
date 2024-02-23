using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-parsed-with-error")]
    public class ThrowedExceptionWhenParseNews : INotification
    {
        public string NewsUrl { get; }

        public string Message { get; }

        public DateTime CreatedAt { get; }

        public ThrowedExceptionWhenParseNews(string newsUrl, string message, DateTime createdAt)
        {
            NewsUrl = newsUrl;
            Message = message;
            CreatedAt = createdAt;
        }
    }
}
