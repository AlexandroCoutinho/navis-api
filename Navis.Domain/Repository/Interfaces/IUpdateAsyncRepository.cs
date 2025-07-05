using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Repository.Interfaces
{
    public interface IUpdateAsyncRepository<T> where T: IEntity
    {
        Task<bool> UpdateAsync(T entity);
    }
}
