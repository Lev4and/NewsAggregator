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
            private readonly IUnitOfWork _unitOfWork;
            private readonly INewsSourceRepository _newsSourceRepository;
            private readonly INewsTagRepository _newsTagRepository;

            public Handler(IUnitOfWork unitOfWork, INewsSourceRepository newsSourceRepository, 
                INewsTagRepository newsTagsRepository)
            {
                _unitOfWork = unitOfWork;
                _newsSourceRepository = newsSourceRepository;
                _newsTagRepository = newsTagsRepository;
            }

            public async Task<GetNewsSourceListDto> Handle(GetNewsSourceListQuery request, 
                CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        var specification = new GetNewsSourceGridSpecification(request.Filters);

                        var newsSourceCount = await _newsSourceRepository.CountAsync(specification, cancellationToken);
                        var newsSourceList = await _newsSourceRepository.FindAsync(specification, cancellationToken);

                        var newsTags = await _newsTagRepository.FindNewsTagsAsync(cancellationToken);

                        var getNewsSourceListDto = new GetNewsSourceListDto(request.Filters, 
                            new PagedResultModel<NewsSource>(newsSourceList, request.Filters.Page, request.Filters.PageSize, 
                                newsSourceCount), newsTags);

                        await transaction.CommitAsync();

                        return getNewsSourceListDto;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();

                        return new GetNewsSourceListDto(new GetNewsSourceListFilters(),
                            new PagedResultModel<NewsSource>(new List<NewsSource>(), 1, 1, 0),
                                new List<NewsTag>());
                    }
                }
            }
        }
    }
}
