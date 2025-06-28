using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Repository.Interfaces
{
    public interface ICreateRepository<T> where T : IEntity
    {
        Task<T> CreateAsync(T entity);
    }
}
