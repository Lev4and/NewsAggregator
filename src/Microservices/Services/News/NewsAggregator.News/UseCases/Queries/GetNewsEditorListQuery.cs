using FluentValidation;
using MediatR;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Specifications;
using System.Transactions;

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
            private readonly IUnitOfWork _unitOfWork;
            private readonly INewsEditorRepository _newsEditorRepository;
            private readonly INewsSourceRepository _newsSourceRepository;

            public Handler(IUnitOfWork unitOfWork, INewsEditorRepository newsEditorRepository, 
                INewsSourceRepository newsSourceRepository)
            {
                _unitOfWork = unitOfWork;
                _newsEditorRepository = newsEditorRepository;
                _newsSourceRepository = newsSourceRepository;
            }

            public async Task<GetNewsEditorListDto> Handle(GetNewsEditorListQuery request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        var specification = new GetNewsEditorGridSpecification(request.Filters);

                        var newsEditorCount = await _newsEditorRepository.CountAsync(specification, cancellationToken);
                        var newsEditorList = await _newsEditorRepository.FindAsync(specification, cancellationToken);

                        var newsSources = await _newsSourceRepository.FindNewsSourcesAsync(cancellationToken);

                        var getNewsEditorListDto = new GetNewsEditorListDto(request.Filters, 
                            new PagedResultModel<NewsEditor>(newsEditorList, request.Filters.Page, 
                                request.Filters.PageSize, newsEditorCount), newsSources);

                        await transaction.CommitAsync();

                        return getNewsEditorListDto;
                    }
                    catch (Exception ex) 
                    {
                        await transaction.RollbackAsync();

                        return new GetNewsEditorListDto(new GetNewsEditorListFilters(),
                            new PagedResultModel<NewsEditor>(new List<NewsEditor>(), 1, 0, 0), new List<NewsSource>());
                    }
                }
            }
        }
    }
}
