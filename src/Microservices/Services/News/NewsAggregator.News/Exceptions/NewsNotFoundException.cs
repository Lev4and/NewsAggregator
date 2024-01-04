namespace NewsAggregator.News.Exceptions
{
    public class NewsNotFoundException : NotFoundException
    {
        public NewsNotFoundException(Guid id) : base($"News {id} not found")
        {

        }

        public NewsNotFoundException(string newsUrl) : base($"News {newsUrl} not found")
        {

        }
    }
}
