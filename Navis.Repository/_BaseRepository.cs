using MongoDB.Driver;
using Navis.Domain.Entities.Interfaces;
using Navis.Domain.Repository.Filters;
using Navis.Domain.Repository.Filters.Interfaces;
using Navis.Domain.Repository.Interfaces;
using Navis.Domain.Repository.PagedResult;
using System.Linq.Expressions;

namespace Navis.Repository
{
    public abstract class BaseRepository<TEntity, TFilter> :
        ICreateAsyncRepository<TEntity>,
        IReadByIdAsyncRepository<TEntity>,
        IReadPagedResultAsyncRepository<TEntity, TFilter>,
        IDeleteAsyncRepository,
        IUpdateAsyncRepository<TEntity>

        where TEntity : IEntity
        where TFilter : IFilter
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;
        private readonly IMongoCollection<TEntity> _mongoCollection;

        public BaseRepository()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017"); //get from configuration
            _mongoDatabase = _mongoClient.GetDatabase("Navis"); //get from configuration
            _mongoCollection = _mongoDatabase.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _mongoCollection.InsertOneAsync(entity);
            var createdEntity = await ReadByIdAsync(entity.Id);
            return createdEntity;
        }

        public virtual async Task<TEntity> ReadByIdAsync(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            var entity = await _mongoCollection.Find(filter).FirstOrDefaultAsync();
            return entity;
        }

        public virtual async Task<PagedResult<TEntity>> ReadPagedResultAsync(TFilter filter)
        {
            PagedResult<TEntity> pagedResult = new PagedResult<TEntity>();
            pagedResult.PageSize = filter.Paging.PageSize;
            pagedResult.PageNumber = filter.Paging.PageNumber;

            FilterDefinition<TEntity> filterDefinition = GetFilterDefinition(filter);
            SortDefinition<TEntity>? sorDefinition = GetSortDefinition<TEntity>(filter.Sorting);

            long totalItems = await _mongoCollection.CountDocumentsAsync(filterDefinition);
            pagedResult.TotalItems = totalItems;

            var entities = await _mongoCollection
                .Find(filterDefinition)
                .Sort(sorDefinition)
                .Skip((filter.Paging.PageNumber - 1) * filter.Paging.PageSize)
                .Limit(filter.Paging.PageSize)
                .ToListAsync();

            pagedResult.Data = entities;

            return pagedResult;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
            var result = await _mongoCollection.ReplaceOneAsync(filter, entity);
            return result.ModifiedCount > 0;
        }

        public virtual async Task<bool> DeleteAsync(string id, bool soft)
        {
            var result = false;

            if (soft)
            {
                result = await SoftDeleteAsync(id);
            }
            else
            {
                result = await DeleteAsync(id);
            }

            return result;
        }


        protected virtual FilterDefinition<TEntity> GetFilterDefinition(TFilter filter)
        {
            var filterBuilder = Builders<TEntity>.Filter;
            var filterDefinition = filterBuilder.Empty;

            filterDefinition &= filterBuilder.Eq(x => x.IsDeleted, false);

            if (!string.IsNullOrWhiteSpace(filter.Id))
            {
                filterDefinition &= filterBuilder.Eq(x => x.Id, filter.Id);
            }

            return filterDefinition;
        }

        protected virtual SortDefinition<TEntity>? GetSortDefinition<T>(Sorting sorting)
        {
            SortDefinition<TEntity>? sortDefinition = null;

            if (sorting != null && !string.IsNullOrWhiteSpace(sorting.SortBy))
            {
                var param = Expression.Parameter(typeof(T), "x");
                var property = Expression.PropertyOrField(param, sorting.SortBy);
                var lambda = Expression.Lambda(property, param);

                var method = sorting.Ascending ? "Ascending" : "Descending";

                var sortDefinitionBuilder = Builders<T>.Sort;

                var genericMethod = typeof(SortDefinitionBuilder<T>).GetMethod(method, new[] { typeof(Expression<Func<T, object>>) });

                if (genericMethod == null)
                {
                    throw new InvalidOperationException("Sort method not found");
                }

                var convertedLambda = Expression.Lambda<Func<T, object>>(Expression.Convert(lambda.Body, typeof(object)), param);

                sortDefinition = (SortDefinition<TEntity>)genericMethod.Invoke(sortDefinitionBuilder, new object[] { convertedLambda })!;
            }

            return sortDefinition;
        }
        
        
        private async Task<bool> SoftDeleteAsync(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            var update = Builders<TEntity>.Update.Set(x => x.IsDeleted, true);
            var result = await _mongoCollection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        private async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            var result = await _mongoCollection.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }
    }
}
