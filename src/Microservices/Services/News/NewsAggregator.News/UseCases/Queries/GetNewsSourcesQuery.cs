using MediatR;
using NewsAggregator.News.Databases.EntityFramework.News.Entities;
using NewsAggregator.News.Databases.EntityFramework.News.Repositories;
using NewsAggregator.News.DTOs;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsSourcesQuery : IRequest<IReadOnlyCollection<NewsSource>>
    {
        internal class Handler : IRequestHandler<GetNewsSourcesQuery, IReadOnlyCollection<NewsSource>>
        {
            private readonly INewsSourceRepository _repository;

            public Handler(INewsSourceRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<NewsSource>> Handle(GetNewsSourcesQuery request, 
                CancellationToken cancellationToken)
            {
                return await _repository.FindNewsSourcesAsync(cancellationToken);
            }
        }
    }
}
