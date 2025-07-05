using Navis.Application.ApplicationModels.Brand;
using Navis.Application.ApplicationModels.Filters;
using Navis.Application.ApplicationModels.PagedResult;

namespace Navis.Application.ApplicationServices.Interfaces
{
    public interface IBrandApplicationService
    {
        Task<BrandApplicationModel> CreateAsync(BrandApplicationModel brandApplicationModel);        
        Task<BrandApplicationModel> ReadByIdAsync(string id);
        Task<PagedResultModel<BrandApplicationModel>> ReadPagedResultAsync(BrandFilterModel brandFilterModel);
        Task<BrandApplicationModel> UpdateAsync(BrandApplicationModel brandApplicationModel);
    }
}
