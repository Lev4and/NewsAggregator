using NewsAggregator.News.Entities;

namespace NewsAggregator.News.DTOs
{
    public class NewsSectionByTagDto
    {
        public NewsTag Tag { get; set; }

        public IReadOnlyCollection<Entities.News> News { get; set; }
    }
}
