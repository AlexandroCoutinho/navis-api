using Navis.Domain.Entities.Interfaces;
using Navis.Domain.Repository.Filters.Interfaces;
using Navis.Domain.Repository.Interfaces;
using Navis.Domain.Repository.PagedResult;
using Navis.Domain.Services.Interfaces;

namespace Navis.Domain.Services
{
    public abstract class BaseDomainService<TEntity, TFilter> : IDomainService<TEntity, TFilter>
        where TEntity : IEntity
        where TFilter : IFilter
    {
        private readonly IRepository<TEntity, TFilter> _repository;

        public BaseDomainService(IRepository<TEntity, TFilter> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = await _repository.CreateAsync(entity);
            return createdEntity;
        }

        public virtual Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<TEntity> ReadByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<PagedResult<TEntity>> ReadPagedResultAsync(TFilter filter)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateAsync(string id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
