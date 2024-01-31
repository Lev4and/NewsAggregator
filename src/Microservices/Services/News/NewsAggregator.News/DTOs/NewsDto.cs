namespace NewsAggregator.News.DTOs
{
    public class NewsDto
    {
        public string Url { get; }

        public string Title { get; }

        public string? SubTitle { get; }

        public string? EditorName { get; }

        public string? PictureUrl { get; }

        public string Description { get; }

        public DateTime? PublishedAt { get; }

        public DateTime ParsedAt { get; }

        public NewsDto(string url, string title, string description, string? subTitle, string? editorName, 
            string? pictureUrl, DateTime? publishedAt, DateTime parsedAt)
        {
            Url = url;
            Title = title;
            SubTitle = subTitle;
            EditorName = editorName;
            PictureUrl = pictureUrl;
            Description = description;
            PublishedAt = publishedAt;
            ParsedAt = parsedAt;
        }
    }
}
