using MediatR;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsReactionsQuery : IRequest<IReadOnlyCollection<NewsReactionDto>>
    {
        public Guid NewsId { get; }

        public GetNewsReactionsQuery(Guid newsId)
        {
            NewsId = newsId;
        }

        internal class Handler : IRequestHandler<GetNewsReactionsQuery, IReadOnlyCollection<NewsReactionDto>>
        {
            private readonly INewsReactionRepository _repository;

            public Handler(INewsReactionRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<NewsReactionDto>> Handle(GetNewsReactionsQuery request, 
                CancellationToken cancellationToken)
            {
                return await _repository.GetNewsReactionsByNewsIdAsync(request.NewsId,
                    cancellationToken);
            }
        }
    }
}
