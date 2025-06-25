using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Repository
{
    public interface ICreateRepository<T> where T : IEntity
    {
        Task<T> CreateAsync(T entity);
    }
}
