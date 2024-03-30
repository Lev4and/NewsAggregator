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
    public class GetNewsListDtoQuery : IRequest<GetNewsListDto>
    {
        public GetNewsListFilters Filters { get; }

        public GetNewsListDtoQuery(GetNewsListFilters filters)
        {
            Filters = filters;
        }

        internal class Validator : AbstractValidator<GetNewsListDtoQuery>
        {
            public Validator()
            {
                RuleFor(query => query.Filters).NotNull();

                RuleFor(query => query.Filters.Page).GreaterThan(0);
                RuleFor(query => query.Filters.PageSize).GreaterThan(0);
            }
        }

        internal class Handler : IRequestHandler<GetNewsListDtoQuery, GetNewsListDto> 
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly INewsRepository _newsRepository;
            private readonly INewsTagRepository _newsTagRepository;
            private readonly INewsEditorRepository _newsEditorRepository;
            private readonly INewsSourceRepository _newsSourceRepository;

            public Handler(IUnitOfWork unitOfWork, INewsRepository newsRepository, INewsTagRepository newsTagRepository, 
                INewsEditorRepository newsEditorRepository, INewsSourceRepository newsSourceRepository)
            {
                _unitOfWork = unitOfWork;
                _newsRepository = newsRepository;
                _newsTagRepository = newsTagRepository;
                _newsEditorRepository = newsEditorRepository;
                _newsSourceRepository = newsSourceRepository;
            }

            public async Task<GetNewsListDto> Handle(GetNewsListDtoQuery request, CancellationToken cancellationToken)
            {
                using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
                {
                    try
                    {
                        var specification = new GetNewsGridSpecification(request.Filters);

                        var newsCount = await _newsRepository.CountAsync(specification, cancellationToken);
                        var newsList = await _newsRepository.FindAsync(specification, cancellationToken);

                        var newsTags = await _newsTagRepository.FindNewsTagsAsync(cancellationToken);
                        var newsSources = await _newsSourceRepository.FindNewsSourcesAsync(cancellationToken);

                        var getNewsListDto = new GetNewsListDto(request.Filters, new PagedResultModel<Entities.News>(newsList, 
                            request.Filters.Page, request.Filters.PageSize, newsCount), newsTags, newsSources);

                        await transaction.CommitAsync();

                        return getNewsListDto;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();

                        return new GetNewsListDto(new GetNewsListFilters(),
                            new PagedResultModel<Entities.News>(new List<Entities.News>(), 1, 1, 0), 
                                new List<NewsTag>(), new List<NewsSource>());
                    }
                }
            }
        }
    }
}
