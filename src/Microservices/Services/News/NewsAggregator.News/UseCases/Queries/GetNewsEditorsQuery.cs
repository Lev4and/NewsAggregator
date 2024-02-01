using MediatR;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsEditorsQuery : IRequest<IReadOnlyCollection<NewsEditor>>
    {
        internal class Handler : IRequestHandler<GetNewsEditorsQuery, IReadOnlyCollection<NewsEditor>>
        {
            private readonly INewsEditorRepository _repository;

            public Handler(INewsEditorRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<NewsEditor>> Handle(GetNewsEditorsQuery request, 
                CancellationToken cancellationToken)
            {
                return await _repository.FindNewsEditorsAsync(cancellationToken);
            }
        }
    }
}
