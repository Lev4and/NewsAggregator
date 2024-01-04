namespace NewsAggregator.News.Exceptions
{
    public class NewsSourceNotFoundException : NotFoundException
    {
        public NewsSourceNotFoundException(Guid id) : base($"News source {id} not found")
        {

        }

        public NewsSourceNotFoundException(string newsSiteHost) : base($"News source {newsSiteHost} not found")
        {
            
        }
    }
}
