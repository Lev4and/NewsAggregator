using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Entities;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Specifications;

namespace NewsAggregator.News.UseCases.Queries
{
    public class GetNewsEditorListQuery : IRequest<GetNewsEditorListDto>
    {
        public GetNewsEditorListFilters Filters { get; }

        public GetNewsEditorListQuery(GetNewsEditorListFilters filters)
        {
            Filters = filters;
        }

        internal class Validator : AbstractValidator<GetNewsEditorListQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Filters).NotNull();

                RuleFor(query => query.Filters.Page).GreaterThan(0);
                RuleFor(query => query.Filters.PageSize).GreaterThan(0);
            }
        }

        internal class Handler : IRequestHandler<GetNewsEditorListQuery, GetNewsEditorListDto>
        {
            private readonly INewsEditorRepository _newsEditorRepository;
            private readonly INewsSourceRepository _newsSourceRepository;

            public Handler(INewsEditorRepository newsEditorRepository, INewsSourceRepository newsSourceRepository)
            {
                _newsEditorRepository = newsEditorRepository;
                _newsSourceRepository = newsSourceRepository;
            }

            public async Task<GetNewsEditorListDto> Handle(GetNewsEditorListQuery request, CancellationToken cancellationToken)
            {
                var specification = new GetNewsEditorGridSpecification(request.Filters);

                var newsEditorCount = await _newsEditorRepository.CountAsync(specification, cancellationToken);
                var newsEditorList = await _newsEditorRepository.FindAsync(specification, cancellationToken);

                var newsSources = await _newsSourceRepository.FindNewsSourcesAsync(cancellationToken);

                return new GetNewsEditorListDto(request.Filters, new PagedResultModel<NewsEditor>(newsEditorList,
                    request.Filters.Page, request.Filters.PageSize, newsEditorCount), newsSources);
            }
        }
    }
}
