using Navis.Application.Models.Brand;
using Navis.Application.Models.Filters;
using Navis.Application.Models.PagedResult;

namespace Navis.Application.ApplicationServices.Interfaces
{
    public interface IBrandApplicationService
    {
        Task<BrandReadModel> CreateAsync(BrandCreateModel brandCrateModel);
        Task<PagedResultModel<BrandReadModel>> ReadPagedResultAsync(BrandFilterModel brandFilterModel);
        Task<BrandReadModel> ReadByIdAsync(string id);
    }
}
