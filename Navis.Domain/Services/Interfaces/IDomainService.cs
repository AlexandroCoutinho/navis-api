using Navis.Domain.Entities.Interfaces;
using Navis.Domain.Repository.Filters.Interfaces;
using Navis.Domain.Repository.PagedResult;

namespace Navis.Domain.Services.Interfaces
{
    public interface IDomainService<TEntity, TFilter>
        where TEntity : IEntity
        where TFilter : IFilter
    {
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> ReadByIdAsync(string id);
        Task<PagedResult<TEntity>> ReadPagedResultAsync(TFilter filter);
        Task<bool> UpdateAsync(string id, TEntity entity);
        Task<bool> DeleteAsync(string id);
    }
}
