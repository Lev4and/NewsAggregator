using MediatR;

namespace NewsAggregator.News.Messages
{
    public class AddedNews : INotification
    {
        public string NewsUrl { get; }

        public AddedNews(string newsUrl)
        {
            NewsUrl = newsUrl;
        }
    }
}
