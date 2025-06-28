using Navis.Domain.Entities.Interfaces;
using Navis.Domain.Repository.PagedResult;

namespace Navis.Domain.Repository.Interfaces
{
    public interface IReadPagedResult<TEntity, TFilter> where TEntity : IEntity
    {
        Task<PagedResult<TEntity>> ReadPagedResultAsync(TFilter filter);
    }
}
