using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Repository.Interfaces
{
    public interface ICreateAsyncRepository<T> where T : IEntity
    {
        Task<T> CreateAsync(T entity);
    }
}
