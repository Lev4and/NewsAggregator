using Microsoft.EntityFrameworkCore;
using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    [Index(nameof(Title))]
    public class NewsSubTitle : EntityBase
    {
        public Guid NewsId { get; set; }

        public string Title { get; set; }

        public virtual News? News { get; set; }
    }
}
