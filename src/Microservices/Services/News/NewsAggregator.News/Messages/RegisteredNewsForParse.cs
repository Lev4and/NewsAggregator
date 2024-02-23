using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-registered")]
    public class RegisteredNewsForParse : INotification
    {
        public string NewsUrl { get; }

        public RegisteredNewsForParse(string newsUrl)
        {
            NewsUrl = newsUrl;
        }
    }
}
