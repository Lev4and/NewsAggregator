using FluentValidation;
using MediatR;
using NewsAggregator.News.Repositories;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetRecentNewsQuery : IRequest<IReadOnlyCollection<Entities.News>>
    {
        public int Count { get; }

        public GetRecentNewsQuery(int count = 10)
        {
            Count = count;
        }

        internal class Validator : AbstractValidator<GetRecentNewsQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Count).GreaterThan(0);
            }
        }

        internal class Handler : IRequestHandler<GetRecentNewsQuery, IReadOnlyCollection<Entities.News>>
        {
            private readonly INewsRepository _repository;

            public Handler(INewsRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<Entities.News>> Handle(GetRecentNewsQuery request,
                CancellationToken cancellationToken)
            {
                return await _repository.FindRecentNewsAsync(request.Count, cancellationToken);
            }
        }
    }
}
