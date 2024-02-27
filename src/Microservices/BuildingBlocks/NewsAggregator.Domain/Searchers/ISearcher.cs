using NewsAggregator.Domain.Entities;

namespace NewsAggregator.Domain.Searchers
{
    public interface ISearcher
    {

    }

    public interface ISearcher<TEntity> where TEntity : EntityBase
    {

    }
}
