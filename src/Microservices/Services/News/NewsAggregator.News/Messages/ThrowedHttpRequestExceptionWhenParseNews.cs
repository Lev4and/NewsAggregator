using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-parsed-with-network-error")]
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
