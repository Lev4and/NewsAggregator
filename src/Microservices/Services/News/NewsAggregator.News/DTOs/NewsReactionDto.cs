namespace NewsAggregator.News.DTOs
{
    public class NewsReactionDto
    {
        public Guid NewsId { get; set; }

        public Guid ReactionId { get; set; }

        public string ReactionTitle { get; set; }

        public string? ReactionIconClass { get; set; }

        public string? ReactionIconColor { get; set; }

        public int Count { get; set; }
    }
}
