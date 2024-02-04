using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Entities;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Specifications;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsSourceListQuery : IRequest<GetNewsSourceListDto>
    {
        public GetNewsSourceListFilters Filters { get; }

        public GetNewsSourceListQuery(GetNewsSourceListFilters filters)
        {
            Filters = filters;
        }

        internal class Validator : AbstractValidator<GetNewsSourceListQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Filters).NotNull();

                RuleFor(query => query.Filters.Page).GreaterThan(0);
                RuleFor(query => query.Filters.PageSize).GreaterThan(0);
            }
        }

        internal class Handler : IRequestHandler<GetNewsSourceListQuery, GetNewsSourceListDto>
        {
            private readonly INewsSourceRepository _newsSourceRepository;

            public Handler(INewsSourceRepository newsSourceRepository)
            {
                _newsSourceRepository = newsSourceRepository;
            }

            public async Task<GetNewsSourceListDto> Handle(GetNewsSourceListQuery request, 
                CancellationToken cancellationToken)
            {
                var specification = new GetNewsSourceGridSpecification(request.Filters);

                var newsSourceCount = await _newsSourceRepository.CountAsync(specification, cancellationToken);
                var newsSourceList = await _newsSourceRepository.FindAsync(specification, cancellationToken);

                return new GetNewsSourceListDto(request.Filters, new PagedResultModel<NewsSource>(newsSourceList,
                    request.Filters.Page, request.Filters.PageSize, newsSourceCount));
            }
        }
    }
}
