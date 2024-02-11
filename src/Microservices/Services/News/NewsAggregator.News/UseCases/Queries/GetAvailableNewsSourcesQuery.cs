using MediatR;
using NewsAggregator.News.Caching;
using NewsAggregator.News.Entities;

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
    }
}
