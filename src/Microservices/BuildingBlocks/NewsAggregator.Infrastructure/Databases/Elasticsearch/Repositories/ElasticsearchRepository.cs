using Elastic.Clients.Elasticsearch;
using NewsAggregator.Domain.Entities;
using NewsAggregator.Domain.Repositories;
using System.Linq.Expressions;

namespace NewsAggregator.Infrastructure.Databases.Elasticsearch.Repositories
{
    public abstract class ElasticsearchRepository : IRepository
    {
        private readonly ElasticsearchClient _client;

        protected ElasticsearchRepository(ElasticsearchClient client)
        {
            _client = client;
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            _client.Index(entity);

            return entity;
        }

        public async Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) 
            where TEntity : EntityBase
        {
            await _client.IndexAsync(entity, cancellationToken);

            return entity;
        }

        public async Task<TEntity?> FindOneByExpressionAsync<TEntity>(Expression<Func<TEntity, bool>> expression, 
            CancellationToken cancellationToken = default) where TEntity : EntityBase
        {
            var response = await _client.SearchAsync<TEntity>(descriptor => descriptor
                .From(0)
                .Size(2)
                .Query(query => query
                    .Bool(boolQuery => boolQuery
                        .Filter(filter => filter
                            .Match(match => match.Field(expression))))));

            return response.Documents.SingleOrDefault(expression.Compile());
        }

        public async Task<TEntity> FindOneByExpressionOrAddAsync<TEntity>(TEntity entity, 
            Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default) 
            where TEntity : EntityBase
        {
            return await FindOneByExpressionOrAddAsync(entity, expression, cancellationToken)
                ?? await AddAsync(entity, cancellationToken);
        }

        public Task<TEntity?> FindOneByIdAsync<TEntity>(Guid id, CancellationToken cancellationToken = default) 
            where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public void Remove<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            _client.Delete<TEntity>(entity.Id);
        }

        public async Task RemoveAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) 
            where TEntity : EntityBase
        {
            await _client.DeleteAsync<TEntity>(entity.Id, cancellationToken);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) 
            where TEntity : EntityBase
        {
            throw new NotImplementedException();
        }
    }

    public abstract class ElasticsearchRepository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly ElasticsearchClient _client;

        protected ElasticsearchRepository(ElasticsearchClient client)
        {
            _client = client;
        }

        public TEntity Add(TEntity entity)
        {
            _client.Index(entity);

            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _client.IndexAsync(entity, cancellationToken);

            return entity;
        }

        public async Task<TEntity?> FindOneByExpressionAsync(Expression<Func<TEntity, bool>> expression, 
            CancellationToken cancellationToken = default)
        {
            var response = await _client.SearchAsync<TEntity>(descriptor => descriptor
                .From(0)
                .Size(2)
                .Query(query => query
                    .Bool(boolQuery => boolQuery
                        .Filter(filter => filter
                            .Match(match => match.Field(expression))))));

            return response.Documents.SingleOrDefault(expression.Compile());
        }

        public async Task<TEntity> FindOneByExpressionOrAddAsync(TEntity entity, Expression<Func<TEntity, bool>> expression, 
            CancellationToken cancellationToken = default)
        {
            return await FindOneByExpressionOrAddAsync(entity, expression, cancellationToken)
                ?? await AddAsync(entity, cancellationToken);
        }

        public Task<TEntity?> FindOneByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            _client.Delete<TEntity>(entity.Id);
        }

        public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _client.DeleteAsync<TEntity>(entity.Id, cancellationToken);
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
