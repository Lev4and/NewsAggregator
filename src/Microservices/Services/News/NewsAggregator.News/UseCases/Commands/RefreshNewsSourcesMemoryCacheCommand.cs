using MediatR;
using NewsAggregator.News.Caching;
using NewsAggregator.News.Extensions;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Commands
{
    public class RefreshNewsSourcesMemoryCacheCommand : IRequest<bool>
    {
        internal class Handler : IRequestHandler<RefreshNewsSourcesMemoryCacheCommand, bool>
        {
            private readonly INewsSourceMemoryCache _cache;
            private readonly INewsSourceRepository _repository;

            public Handler(INewsSourceMemoryCache cache, INewsSourceRepository repository)
            {
                _cache = cache;
                _repository = repository;
            }

            public async Task<bool> Handle(RefreshNewsSourcesMemoryCacheCommand request, 
                CancellationToken cancellationToken)
            {
                var newsSources = await _repository.FindAvailableNewsSourcesExtendedAsync();

                await _cache.RemoveAvailableNewsSourcesAsync();

                foreach (var newsSource in newsSources)
                {
                    await _cache.RemoveNewsSourceByIdAsync(newsSource.Id, cancellationToken);

                    await _cache.RemoveNewsSourceByDomainAsync(new Uri(newsSource.SiteUrl).GetDomain(),
                        cancellationToken);

                    await _cache.RemoveNewsSourceBySiteUrlAsync(newsSource.SiteUrl, cancellationToken);

                    await _cache.GetNewsSourceByIdAsync(newsSource.Id,
                        () => Task.FromResult(newsSource), cancellationToken);

                    await _cache.GetNewsSourceByDomainAsync(new Uri(newsSource.SiteUrl).GetDomain(),
                        () => Task.FromResult(newsSource), cancellationToken);

                    await _cache.GetNewsSourceBySiteUrlAsync(newsSource.SiteUrl,
                        () => Task.FromResult(newsSource), cancellationToken);
                }

                await _cache.GetAvailableNewsSourcesAsync(() => Task.FromResult(newsSources), 
                    cancellationToken);

                return true;
            }
        }
    }
}
