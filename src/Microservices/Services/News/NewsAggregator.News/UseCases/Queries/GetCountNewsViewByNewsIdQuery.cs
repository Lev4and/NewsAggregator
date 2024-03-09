using MediatR;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetCountNewsViewByNewsIdQuery : IRequest<long>
    {
        public Guid NewsId { get; }

        public GetCountNewsViewByNewsIdQuery(Guid newsId)
        {
            NewsId = newsId;
        }

        internal class Handler : IRequestHandler<GetCountNewsViewByNewsIdQuery, long>
        {
            private readonly INewsViewRepository _repository;

            public Handler(INewsViewRepository repository)
            {
                _repository = repository;
            }

            public async Task<long> Handle(GetCountNewsViewByNewsIdQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetCountViewsByNewsIdAsync(request.NewsId, cancellationToken);
            }
        }
    }
}
