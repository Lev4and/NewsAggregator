using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-processed")]
    public class ProcessedNews : INotification
    {
        public string NewsUrl { get; }

        public ProcessedNews(string newsUrl)
        {
            NewsUrl = newsUrl;
        }
    }
}
