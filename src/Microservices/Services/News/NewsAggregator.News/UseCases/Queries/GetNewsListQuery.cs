using FluentValidation;
using MediatR;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Specifications;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsListQuery : IRequest<IReadOnlyCollection<Entities.News>>
    {
        public GetNewsListFilters Filters { get; }

        public GetNewsListQuery(GetNewsListFilters filters)
        {
            Filters = filters;
        }

        internal class Validator : AbstractValidator<GetNewsListQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Filters).NotNull();
            }
        }

        internal class Handler : IRequestHandler<GetNewsListQuery, IReadOnlyCollection<Entities.News>>
        {
            private readonly INewsRepository _newsRepository;

            public Handler(INewsRepository newsRepository)
            {
                _newsRepository = newsRepository;
            }

            public async Task<IReadOnlyCollection<Entities.News>> Handle(GetNewsListQuery request, 
                CancellationToken cancellationToken)
            {
                var specification = new GetNewsGridSpecification(request.Filters);

                return await _newsRepository.FindAsync(specification, cancellationToken);
            }
        }
    }
}
