using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters;

namespace Navis.Domain.Services.Interfaces
{
    public interface IModelDomainService : IDomainService<Model, ModelFilter>
    {
    }
}
