using Navis.Domain.Entities;
using Navis.Domain.Services.Interfaces;

namespace Navis.Domain.Services
{
    public class BrandDomainService : IBrandDomainService
    {
        public async Task<Brand> CreateAsync(Brand brand)
        {
            await Task.FromResult("");
            return new Brand() { Id = "teste", Name = "teste" };
        }
    }
}
