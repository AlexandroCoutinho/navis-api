using Navis.Domain.Entities.Interfaces;
using Navis.Domain.Repository.Filters;
using Navis.Domain.Repository.PagedResult;

namespace Navis.Domain.Services.Interfaces
{
    public interface IDomainService<T> where T : IEntity
    {
        Task<T> CreateAsync(T entity);
        Task<PagedResult<T>> ReadPagedResultAsync(BrandFilter brandFilter);
        Task<T> ReadByIdAsync(string id);
    }
}
