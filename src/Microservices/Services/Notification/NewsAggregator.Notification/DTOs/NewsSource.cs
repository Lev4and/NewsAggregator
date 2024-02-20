namespace NewsAggregator.Notification.DTOs
{
    public class NewsSource
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public NewsSourceLogo? Logo { get; set; }
    }
}
