using Navis.Domain.Entities;
using Navis.Domain.Repository;
using Navis.Domain.Services.Interfaces;

namespace Navis.Domain.Services
{
    public class BrandDomainService : IBrandDomainService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandDomainService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<Brand> CreateAsync(Brand brand)
        {
            var createdBrand = await _brandRepository.CreateAsync(brand);
            return createdBrand;
        }
    }
}
