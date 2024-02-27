using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Searchers;

namespace NewsAggregator.Infrastructure.Databases.EntityFramework.Searchers
{
    public interface IEntityFrameworkSearcher : ISearcher
    {

    }

    public interface IEntityFrameworkSearcher<TEntity> : ISearcher<TEntity>
        where TEntity : EntityBase
    {

    }
}
