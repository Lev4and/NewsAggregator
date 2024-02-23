using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Entities;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Specifications;
using System.Transactions;

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
                using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                        TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var specification = new GetNewsSourceGridSpecification(request.Filters);

                        var newsSourceCount = await _newsSourceRepository.CountAsync(specification, cancellationToken);
                        var newsSourceList = await _newsSourceRepository.FindAsync(specification, cancellationToken);

                        var getNewsSourceListDto = new GetNewsSourceListDto(request.Filters, 
                            new PagedResultModel<NewsSource>(newsSourceList, request.Filters.Page, request.Filters.PageSize, 
                                newsSourceCount));

                        transaction.Complete();

                        return getNewsSourceListDto;
                    }
                    catch (Exception ex)
                    {
                        return new GetNewsSourceListDto(new GetNewsSourceListFilters(),
                            new PagedResultModel<NewsSource>(new List<NewsSource>(), 1, 1, 0));
                    }
                }
            }
        }
    }
}
