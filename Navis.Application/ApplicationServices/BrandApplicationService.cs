using AutoMapper;
using Navis.Application.ApplicationServices.Interfaces;
using Navis.Application.Models.Brand;
using Navis.Application.Models.Filters;
using Navis.Application.Models.PagedResult;
using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters;
using Navis.Domain.Services.Interfaces;

namespace Navis.Application.ApplicationServices
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

        public async Task<BrandReadModel> ReadByIdAsync(string id)
        {
            var brand = await _brandDomainService.ReadByIdAsync(id);
            var brandReadModel = _mapper.Map<BrandReadModel>(brand);
            return brandReadModel;
        }

        public async Task<PagedResultModel<BrandReadModel>> ReadPagedResultAsync(BrandFilterModel brandFilterModel)
        {
            var brandFilter = _mapper.Map<BrandFilter>(brandFilterModel);

            var pagedResult = await _brandDomainService.ReadPagedResultAsync(brandFilter);
            var pagedResultModel = _mapper.Map<PagedResultModel<BrandReadModel>>(pagedResult);
            return pagedResultModel;
        }
    }
}
