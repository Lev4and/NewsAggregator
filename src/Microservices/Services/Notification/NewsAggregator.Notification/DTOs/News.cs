namespace NewsAggregator.Notification.DTOs
{
    public class News
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        public string Title { get; set; }

        public DateTime? PublishedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public DateTime ParsedAt { get; set; }

        public DateTime AddedAt { get; set; }

        public NewsEditor? Editor { get; set; }

    }
}
