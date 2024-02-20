namespace NewsAggregator.Notification.DTOs
{
    public class NewsEditor
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public NewsSource? Source { get; set; }
    }
}
