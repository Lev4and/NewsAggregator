namespace NewsAggregator.News.Exceptions
{
    public class NewsEditorNotFoundException : NotFoundException
    {
        public NewsEditorNotFoundException(Guid id) : base($"News editor {id} not found")
        {
            
        }
    }
}
