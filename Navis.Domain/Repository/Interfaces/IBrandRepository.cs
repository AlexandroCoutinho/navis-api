using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters;

namespace Navis.Domain.Repository.Interfaces
{
    public interface IBrandRepository :
        ICreateAsyncRepository<Brand>,
        IReadByIdAsyncRepository<Brand>,
        IReadPagedResultAsyncRepository<Brand, BrandFilter>,
        IDeleteAsyncRepository,
        IUpdateAsyncRepository<Brand>
    {
    }
}
