using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters;

namespace Navis.Domain.Repository.Interfaces
{
    public interface IBrandRepository :
        ICreateRepository<Brand>,
        IReadByIdRepository<Brand>,
        IReadPagedResult<Brand, BrandFilter>
    {
    }
}
