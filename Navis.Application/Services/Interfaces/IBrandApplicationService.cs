using Navis.Application.Models.Brand;

namespace Navis.Application.Services.Interfaces
{
    public interface IBrandApplicationService
    {
        Task<BrandReadModel> CreateAsync(BrandCreateModel brandCrateModel);
    }
}
