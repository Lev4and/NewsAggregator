using NewsAggregator.Domain.Entities;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Entities;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Searchers;
using NewsAggregator.News.Specifications;
using System.Transactions;

namespace NewsAggregator.News.Databases.EntityFramework.News.Searchers
{
    public class NewsEditorSearcher : NewsDbEntityFrameworkSearcher<NewsEditor>, INewsEditorSearcher
    {
        private readonly INewsEditorRepository _repository;

        public NewsEditorSearcher(NewsDbContext dbContext, INewsEditorRepository repository) : base(dbContext)
        {
            _repository = repository;
        }

        public async Task<PagedResultModel<NewsEditor>> SearchByFiltersAsync(GetNewsEditorListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions() { IsolationLevel = IsolationLevel.RepeatableRead },
                        TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var specification = new GetNewsEditorGridSpecification(filters);

                    var count = await _repository.CountAsync(specification, cancellationToken);
                    var list = await _repository.FindAsync(specification, cancellationToken);

                    var result = new PagedResultModel<NewsEditor>(list, filters.Page,
                        filters.PageSize, count);

                    transaction.Complete();

                    return result;
                }
                catch
                {
                    return new PagedResultModel<NewsEditor>(new List<NewsEditor>(), 1,
                        1, 0);
                }
            }
        }
    }
}
