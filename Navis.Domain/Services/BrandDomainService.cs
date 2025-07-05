using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters;
using Navis.Domain.Repository.Interfaces;
using Navis.Domain.Repository.PagedResult;
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
        public async Task<Brand> ReadByIdAsync(string id)
        {
            var brand = await _brandRepository.ReadByIdAsync(id);
            return brand;
        }
        public async Task<PagedResult<Brand>> ReadPagedResultAsync(BrandFilter brandFilter)
        {
            var pagedResult = await _brandRepository.ReadPagedResultAsync(brandFilter);
            return pagedResult;
        }
        public Task<bool> UpdateAsync(string id, Brand entity)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
