using FluentValidation;
using MediatR;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetRecentNewsExtendedQuery : IRequest<IReadOnlyCollection<Entities.News>>
    {
        public int Count => 1;

        public GetRecentNewsExtendedQuery()
        {
            
        }

        internal class Validator : AbstractValidator<GetRecentNewsExtendedQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Count).GreaterThan(0);
            }
        }

        internal class Handler : IRequestHandler<GetRecentNewsExtendedQuery, IReadOnlyCollection<Entities.News>>
        {
            private readonly INewsRepository _repository;

            public Handler(INewsRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<Entities.News>> Handle(GetRecentNewsExtendedQuery request, 
                CancellationToken cancellationToken)
            {
                return await _repository.FindRecentNewsExtendedAsync(request.Count, cancellationToken);
            }
        }
    }
}
