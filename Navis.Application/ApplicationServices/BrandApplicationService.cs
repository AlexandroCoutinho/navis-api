using AutoMapper;
using Navis.Application.ApplicationModels.Brand;
using Navis.Application.ApplicationModels.Filters;
using Navis.Application.ApplicationModels.PagedResult;
using Navis.Application.ApplicationServices.Interfaces;
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

        public async Task<BrandApplicationModel> CreateAsync(BrandApplicationModel brandApplicationModel)
        {
            var brand = _mapper.Map<Brand>(brandApplicationModel);

            brand = await _brandDomainService.CreateAsync(brand);

            var brandReadModel = _mapper.Map<BrandApplicationModel>(brand);

            return brandReadModel;
        }

        public async Task<BrandApplicationModel> ReadByIdAsync(string id)
        {
            var brand = await _brandDomainService.ReadByIdAsync(id);
            var brandReadModel = _mapper.Map<BrandApplicationModel>(brand);
            return brandReadModel;
        }

        public async Task<PagedResultModel<BrandApplicationModel>> ReadPagedResultAsync(BrandFilterModel brandFilterModel)
        {
            var brandFilter = _mapper.Map<BrandFilter>(brandFilterModel);

            var pagedResult = await _brandDomainService.ReadPagedResultAsync(brandFilter);
            var pagedResultModel = _mapper.Map<PagedResultModel<BrandApplicationModel>>(pagedResult);
            return pagedResultModel;
        }

        public async Task<BrandApplicationModel> UpdateAsync(BrandApplicationModel brandApplicationModel)
        {
            await Task.FromResult("");
            throw new NotImplementedException();
        }
    }
}
