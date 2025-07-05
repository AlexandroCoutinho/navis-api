using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Repository.Interfaces
{
    public interface IReadByIdAsyncRepository<T> where T : IEntity
    {
        Task<T> ReadByIdAsync(string id);
    }
}
