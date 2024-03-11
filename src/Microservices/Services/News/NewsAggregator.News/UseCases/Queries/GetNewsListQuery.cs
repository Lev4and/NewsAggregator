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
    public class GetNewsListQuery : IRequest<GetNewsListDto>
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

                RuleFor(query => query.Filters.Page).GreaterThan(0);
                RuleFor(query => query.Filters.PageSize).GreaterThan(0);
            }
        }

        internal class Handler : IRequestHandler<GetNewsListQuery, GetNewsListDto> 
        {
            private readonly INewsRepository _newsRepository;
            private readonly INewsTagsRepository _newsTagsRepository;
            private readonly INewsEditorRepository _newsEditorRepository;
            private readonly INewsSourceRepository _newsSourceRepository;

            public Handler(INewsRepository newsRepository, INewsTagsRepository newsTagsRepository, 
                INewsEditorRepository newsEditorRepository, INewsSourceRepository newsSourceRepository)
            {
                _newsRepository = newsRepository;
                _newsTagsRepository = newsTagsRepository;
                _newsEditorRepository = newsEditorRepository;
                _newsSourceRepository = newsSourceRepository;
            }

            public async Task<GetNewsListDto> Handle(GetNewsListQuery request, CancellationToken cancellationToken)
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                        TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var specification = new GetNewsGridSpecification(request.Filters);

                        var newsCount = await _newsRepository.CountAsync(specification, cancellationToken);
                        var newsList = await _newsRepository.FindAsync(specification, cancellationToken);

                        var newsTags = await _newsTagsRepository.FindNewsTagsAsync(cancellationToken);
                        var newsEditors = await _newsEditorRepository.FindNewsEditorsAsync(cancellationToken);
                        var newsSources = await _newsSourceRepository.FindNewsSourcesAsync(cancellationToken);

                        var getNewsListDto = new GetNewsListDto(request.Filters, new PagedResultModel<Entities.News>(newsList, 
                            request.Filters.Page, request.Filters.PageSize, newsCount), newsTags, newsEditors, newsSources);

                        transaction.Complete();

                        return getNewsListDto;
                    }
                    catch (Exception ex)
                    {
                        return new GetNewsListDto(new GetNewsListFilters(),
                            new PagedResultModel<Entities.News>(new List<Entities.News>(), 1, 1, 0), 
                                new List<NewsTag>(), new List<NewsEditor>(), new List<NewsSource>());
                    }
                }
            }
        }
    }
}
