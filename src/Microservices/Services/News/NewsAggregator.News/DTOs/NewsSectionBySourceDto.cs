using NewsAggregator.News.Entities;

namespace NewsAggregator.News.DTOs
{
    public class NewsSectionBySourceDto
    {
        public NewsSource Source { get; set; }

        public IReadOnlyCollection<Entities.News> News { get; set; }
    }
}
