using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters;
using Navis.Domain.Repository.Interfaces;
using Navis.Domain.Services.Interfaces;

namespace Navis.Domain.Services
{
    public class ModelDomainService : BaseDomainService<Model, ModelFilter>, IModelDomainService
    {
        public ModelDomainService(IModelRepository modelRepository) : base(modelRepository)
        {
        }
    }
}
