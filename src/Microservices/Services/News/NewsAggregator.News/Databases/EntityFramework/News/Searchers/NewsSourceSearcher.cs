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
    public class NewsSourceSearcher : NewsDbEntityFrameworkSearcher<NewsSource>, INewsSourceSearcher
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INewsSourceRepository _repository;

        public NewsSourceSearcher(NewsDbContext dbContext, IUnitOfWork unitOfWork, INewsSourceRepository repository) : 
            base(dbContext)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<PagedResultModel<NewsSource>> SearchByFiltersAsync(GetNewsSourceListFilters filters, 
            CancellationToken cancellationToken)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var specification = new GetNewsSourceGridSpecification(filters);

                    var count = await _repository.CountAsync(specification, cancellationToken);
                    var list = await _repository.FindAsync(specification, cancellationToken);

                    var result = new PagedResultModel<NewsSource>(list, filters.Page,
                        filters.PageSize, count);

                    await transaction.CommitAsync();

                    return result;
                }
                catch
                {
                    await transaction.RollbackAsync();

                    return new PagedResultModel<NewsSource>(new List<NewsSource>(), 1,
                        1, 0);
                }
            }
        }
    }
}
