using MediatR;
using NewsAggregator.News.Caching;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsSourcesQuery : IRequest<IReadOnlyCollection<NewsSource>>
    {
        internal class Handler : IRequestHandler<GetNewsSourcesQuery, IReadOnlyCollection<NewsSource>>
        {
            private readonly INewsSourceMemoryCache _cache;
            private readonly INewsSourceRepository _repository;

            public Handler(INewsSourceMemoryCache cache, INewsSourceRepository repository)
            {
                _cache = cache;
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<NewsSource>> Handle(GetNewsSourcesQuery request, 
                CancellationToken cancellationToken)
            {
                return await _cache.GetNewsSourcesAsync(
                    async () =>
                    {
                        return await _repository.FindNewsSourcesAsync(cancellationToken);
                    },
                    cancellationToken);
            }
        }
    }
}
