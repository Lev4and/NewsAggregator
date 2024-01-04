using MediatR;

namespace NewsAggregator.News.Messages
{
    public class CheckedNewsOnNotExists : INotification
    {
        public string NewsUrl { get; }

        public CheckedNewsOnNotExists(string newsUrl)
        {
            NewsUrl = newsUrl;
        }
    }
}
