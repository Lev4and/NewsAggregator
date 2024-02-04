﻿using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Entities
{
    public class NewsVideo : EntityBase
    {
        public Guid NewsId { get; set; }

        public string Url { get; set; }

        public virtual News? News { get; set; }
    }
}
