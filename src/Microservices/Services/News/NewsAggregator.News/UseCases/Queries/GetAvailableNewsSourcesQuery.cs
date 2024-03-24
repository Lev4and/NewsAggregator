using MediatR;
using NewsAggregator.Domain.Infrastructure.MessageBrokers;
using NewsAggregator.News.Caching;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Messages;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetAvailableNewsSourcesQuery : IRequest<IReadOnlyCollection<NewsSource>>
    {
        internal class Handler : IRequestHandler<GetAvailableNewsSourcesQuery, IReadOnlyCollection<NewsSource>>
        {
            private readonly INewsSourceMemoryCache _cache;

            public Handler(INewsSourceMemoryCache cache)
            {
                _cache = cache;
            }

            public async Task<IReadOnlyCollection<NewsSource>> Handle(GetAvailableNewsSourcesQuery request,
                CancellationToken cancellationToken)
            {
                return await _cache.GetAvailableNewsSourcesAsync(cancellationToken);
            }
        }

        internal class NewsSourceListNotFoundNotificationHandler : INotificationHandler<NewsSourceListNotFound> 
        {
            private readonly IMessageBus _messageBus;

            public NewsSourceListNotFoundNotificationHandler(IMessageBus messageBus)
            {
                _messageBus = messageBus;
            }

            public async Task Handle(NewsSourceListNotFound notification, CancellationToken cancellationToken)
            {
                await _messageBus.SendAsync(notification, cancellationToken);
            }
        }
    }
}
