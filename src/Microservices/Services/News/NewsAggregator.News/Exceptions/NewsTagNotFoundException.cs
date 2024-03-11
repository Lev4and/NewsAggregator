namespace NewsAggregator.News.Exceptions
{
    public class NewsTagNotFoundException : NotFoundException
    {
        public NewsTagNotFoundException(Guid id) : base($"News tag by {id} not found")
        {

        }

        public NewsTagNotFoundException(string name) : base($"News tag {name} not found")
        {

        }
    }
}
