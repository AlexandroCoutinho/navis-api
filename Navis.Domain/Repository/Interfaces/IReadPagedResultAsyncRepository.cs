using Navis.Domain.Entities.Interfaces;
using Navis.Domain.Repository.Filters.Interfaces;
using Navis.Domain.Repository.PagedResult;

namespace Navis.Domain.Repository.Interfaces
{
    public interface IReadPagedResultAsyncRepository<TEntity, TFilter> 
        where TEntity : IEntity
        where TFilter: IFilter
    {
        Task<PagedResult<TEntity>> ReadPagedResultAsync(TFilter filter);
    }
}
