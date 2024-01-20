﻿using NewsAggregator.Domain.Entities;

namespace NewsAggregator.News.Databases.EntityFramework.News.Entities
{
    public class NewsParseError : EntityBase
    {
        public string NewsUrl { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
