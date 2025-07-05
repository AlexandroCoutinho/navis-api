using AutoMapper;
using Navis.Application.ApplicationModels;
using Navis.Application.ApplicationModels.Filters;
using Navis.Application.ApplicationServices.Interfaces;
using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters;
using Navis.Domain.Services.Interfaces;

namespace Navis.Application.ApplicationServices
{
    public class ModelApplicationService : BaseApplicationService<ModelApplicationModel, ModelFilterModel, Model, ModelFilter>, IModelApplicationService
    {
        public ModelApplicationService(IModelDomainService modelDomainService, IMapper mapper) : base(modelDomainService, mapper)
        {
        }
    }
}
