using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Services.Interfaces
{
    public interface IDomainService<T> where T : IEntity
    {
        Task<T> CreateAsync(T entity);
    }
}
