using MediatR;

namespace NewsAggregator.News.Messages
{
    public class RegisteredNewsForParse : INotification
    {
        public string NewsUrl { get; }

        public RegisteredNewsForParse(string newsUrl)
        {
            NewsUrl = newsUrl;
        }
    }
}
