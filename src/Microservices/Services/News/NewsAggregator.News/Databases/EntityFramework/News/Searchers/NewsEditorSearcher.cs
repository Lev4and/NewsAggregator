using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Infrastructure.Databases;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly INewsEditorRepository _repository;

        public NewsEditorSearcher(NewsDbContext dbContext, IUnitOfWork unitOfWork, INewsEditorRepository repository) :
            base(dbContext)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<PagedResultModel<NewsEditor>> SearchByFiltersAsync(GetNewsEditorListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var specification = new GetNewsEditorGridSpecification(filters);

                    var count = await _repository.CountAsync(specification, cancellationToken);
                    var list = await _repository.FindAsync(specification, cancellationToken);

                    var result = new PagedResultModel<NewsEditor>(list, filters.Page,
                        filters.PageSize, count);

                    await transaction.CommitAsync();

                    return result;
                }
                catch
                {
                    await transaction.RollbackAsync();

                    return new PagedResultModel<NewsEditor>(new List<NewsEditor>(), 1,
                        1, 0);
                }
            }
        }
    }
}
