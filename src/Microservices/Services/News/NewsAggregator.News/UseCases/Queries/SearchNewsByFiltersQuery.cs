using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Entities;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Searchers;

namespace NewsAggregator.News.UseCases.Queries
{
    public class SearchNewsByFiltersQuery : IRequest<PagedResultModel<Entities.News>>
    {
        public GetNewsListFilters Filters { get; }

        public SearchNewsByFiltersQuery(GetNewsListFilters filters)
        {
            Filters = filters;
        }

        internal class Validator : AbstractValidator<SearchNewsByFiltersQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Filters).NotNull();

                RuleFor(query => query.Filters.Page).GreaterThan(0);
                RuleFor(query => query.Filters.PageSize).GreaterThan(0);
            }
        }

        internal class Handler : IRequestHandler<SearchNewsByFiltersQuery, PagedResultModel<Entities.News>>
        {
            private readonly INewsSearcher _searcher;

            public Handler(INewsSearcher searcher)
            {
                _searcher = searcher;
            }

            public async Task<PagedResultModel<Entities.News>> Handle(SearchNewsByFiltersQuery request, 
                CancellationToken cancellationToken)
            {
                return await _searcher.SearchByFiltersAsync(request.Filters, cancellationToken);
            }
        }
    }
}
