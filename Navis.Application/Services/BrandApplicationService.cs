using Navis.Application.Models;
using Navis.Application.Services.Interfaces;
using Navis.Domain.Services.Interfaces;
using Navis.Domain.Entities;

namespace Navis.Application.Services
{
    public class BrandApplicationService : IBrandApplicationService
    {
        private readonly IBrandDomainService _brandDomainService;

        public BrandApplicationService(IBrandDomainService brandDomainService)
        {
            _brandDomainService = brandDomainService;
        }

        public async Task<BrandReadModel> CreateAsync(BrandCreateModel brandCrateModel)
        {
            var result = await _brandDomainService.CreateAsync(new Brand());
            return new BrandReadModel();
        }
    }
}
