using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-found")]
    public class FoundNotExistedNews : INotification
    {
        public string NewsUrl { get; }

        public FoundNotExistedNews(string newsUrl)
        {
            NewsUrl = newsUrl;
        }
    }
}
