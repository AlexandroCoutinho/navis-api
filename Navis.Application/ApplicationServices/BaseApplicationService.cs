using AutoMapper;
using Navis.Application.ApplicationModels.PagedResult;
using Navis.Application.ApplicationServices.Interfaces;
using Navis.Domain.Entities.Interfaces;
using Navis.Domain.Repository.Filters.Interfaces;
using Navis.Domain.Services.Interfaces;

namespace Navis.Application.ApplicationServices
{
    public abstract class BaseApplicationService<TApplicationModel, TFilterApplicationModel, TEntity, TFilter> : IApplicationService<TApplicationModel, TFilterApplicationModel>
    where TEntity : IEntity
    where TFilter : IFilter
    {
        private readonly IDomainService<TEntity, TFilter> _domainService;
        private readonly IMapper _mapper;

        protected BaseApplicationService(IDomainService<TEntity, TFilter> domainService, IMapper mapper)
        {
            _domainService = domainService;
            _mapper = mapper;
        }

        public virtual async Task<TApplicationModel> CreateAsync(TApplicationModel applicationModel)
        {
            var domainEntity = _mapper.Map<TEntity>(applicationModel);
            var createdEntity = await _domainService.CreateAsync(domainEntity);
            var createdApplicationModel = _mapper.Map<TApplicationModel>(createdEntity);
            return createdApplicationModel;
        }

        public virtual async Task<TApplicationModel> ReadByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<PagedResultModel<TApplicationModel>> ReadPagedResultAsync(TFilterApplicationModel filter)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> UpdateAsync(string id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
