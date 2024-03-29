﻿using MassTransit;
using MediatR;

namespace NewsAggregator.News.Messages
{
    [MessageUrn("news-added")]
    public class AddedNews : INotification
    {
        public string NewsUrl { get; }

        public AddedNews(string newsUrl)
        {
            NewsUrl = newsUrl;
        }
    }
}
