using MediatR;
using NewsAggregator.News.Caching;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetAvailableNewsSourcesQuery : IRequest<IReadOnlyCollection<NewsSource>>
    {
        internal class Handler : IRequestHandler<GetAvailableNewsSourcesQuery, IReadOnlyCollection<NewsSource>>
        {
            private readonly INewsSourceMemoryCache _cache;
            private readonly INewsSourceRepository _repository;

            public Handler(INewsSourceMemoryCache cache, INewsSourceRepository repository)
            {
                _cache = cache;
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<NewsSource>> Handle(GetAvailableNewsSourcesQuery request,
                CancellationToken cancellationToken)
            {
                return await _cache.GetAvailableNewsSourcesAsync(async () => 
                    await _repository.FindAvailableNewsSourcesExtendedAsync(cancellationToken), cancellationToken);
            }
        }
    }
}
