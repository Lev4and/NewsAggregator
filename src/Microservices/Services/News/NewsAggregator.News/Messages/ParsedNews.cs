using MediatR;
using NewsAggregator.News.DTOs;

namespace NewsAggregator.News.Messages
{
    public class ParsedNews : INotification
    {
        public NewsDto News { get; }

        public ParsedNews(NewsDto news)
        {
            News = news;
        }
    }
}
