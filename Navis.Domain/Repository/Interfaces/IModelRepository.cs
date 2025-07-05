using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters;

namespace Navis.Domain.Repository.Interfaces
{
    public interface IModelRepository: IRepository<Model, ModelFilter>
    {
    }
}
