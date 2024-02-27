using NewsAggregator.Domain.Entities;
using NewsAggregator.Infrastructure.Databases.Fake.Indexers;

namespace NewsAggregator.News.Databases.Fake.News.Indexers
{
    public class NewsDbFakeIndexer : FakeIndexer
    {

    }

    public class NewsDbFakeIndexer<TEntity> : FakeIndexer<TEntity>
        where TEntity : EntityBase
    {

    }
}
