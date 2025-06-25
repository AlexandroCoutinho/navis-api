using AutoMapper;
using Navis.Application.Models.Brand;
using Navis.Application.Services.Interfaces;
using Navis.Domain.Entities;
using Navis.Domain.Services.Interfaces;

namespace Navis.Application.Services
{
    public class BrandApplicationService : IBrandApplicationService
    {
        private readonly IBrandDomainService _brandDomainService;
        private readonly IMapper _mapper;

        public BrandApplicationService(IBrandDomainService brandDomainService, IMapper mapper)
        {
            _brandDomainService = brandDomainService;
            _mapper = mapper;
        }

        public async Task<BrandReadModel> CreateAsync(BrandCreateModel brandCrateModel)
        {
            var brand = _mapper.Map<Brand>(brandCrateModel);

            brand = await _brandDomainService.CreateAsync(brand);

            var brandReadModel = _mapper.Map<BrandReadModel>(brand);

            return brandReadModel;
        }
    }
}
