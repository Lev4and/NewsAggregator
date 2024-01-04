namespace NewsAggregator.News.DTOs
{
    public class NewsDto
    {
        public string Url { get; }

        public string Title { get; }

        public string? SubTitle { get; }

        public string? EditorName { get; }

        public string? PictureUrl { get; }

        public string? Description { get; }

        public DateTime? PublishedAt { get; }

        public NewsDto(string url, string title, string? subTitle, string? editorName, string? pictureUrl, 
            string? description, DateTime? publishedAt)
        {
            Url = url;
            Title = title;
            SubTitle = subTitle;
            EditorName = editorName;
            PictureUrl = pictureUrl;
            Description = description;
            PublishedAt = publishedAt;
        }
    }
}
