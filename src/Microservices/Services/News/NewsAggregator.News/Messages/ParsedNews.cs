using MassTransit;
using MediatR;
using NewsAggregator.News.DTOs;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-parsed")]
    public class ParsedNews : INotification
    {
        public NewsDto News { get; }

        public ParsedNews(NewsDto news)
        {
            News = news;
        }
    }
}
