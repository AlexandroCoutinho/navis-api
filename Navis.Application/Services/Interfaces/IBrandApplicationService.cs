using Navis.Application.Models;

namespace Navis.Application.Services.Interfaces
{
    public interface IBrandApplicationService
    {
        Task<BrandReadModel> CreateAsync(BrandCreateModel brandCrateModel);
    }
}
