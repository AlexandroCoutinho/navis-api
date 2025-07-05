using Navis.Domain.Entities.Interfaces;
using Navis.Domain.Repository.Filters.Interfaces;

namespace Navis.Domain.Repository.Interfaces
{
    public interface IRepository<TEntity, TFilter> :
        ICreateAsyncRepository<TEntity>,
        IReadByIdAsyncRepository<TEntity>,
        IReadPagedResultAsyncRepository<TEntity, TFilter>,
        IDeleteAsyncRepository,
        IUpdateAsyncRepository<TEntity>
        where TEntity : IEntity
        where TFilter : IFilter
    {
    }
}
