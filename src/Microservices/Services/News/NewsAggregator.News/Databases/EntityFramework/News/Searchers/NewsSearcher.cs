using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Infrastructure.Databases;
using NewsAggregator.News.DTOs;
using NewsAggregator.News.Repositories;
using NewsAggregator.News.Searchers;
using NewsAggregator.News.Specifications;
using System.Transactions;

namespace NewsAggregator.News.Databases.EntityFramework.News.Searchers
{
    public class NewsSearcher : NewsDbEntityFrameworkSearcher<Entities.News>, INewsSearcher
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INewsRepository _repository;

        public NewsSearcher(NewsDbContext dbContext, IUnitOfWork unitOfWork, INewsRepository repository) : base(dbContext)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<PagedResultModel<Entities.News>> SearchByFiltersAsync(GetNewsListFilters filters, 
            CancellationToken cancellationToken = default)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    var specification = new GetNewsGridSpecification(filters);

                    var count = await _repository.CountAsync(specification, cancellationToken);
                    var list = await _repository.FindAsync(specification, cancellationToken);

                    var result = new PagedResultModel<Entities.News>(list, filters.Page, 
                        filters.PageSize, count);

                    await transaction.CommitAsync();

                    return result;
                }
                catch
                {
                    await transaction.RollbackAsync();

                    return new PagedResultModel<Entities.News>(new List<Entities.News>(), 1, 
                        1, 0);
                }
            }
        }
    }
}
