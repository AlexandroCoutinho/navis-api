using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters;
using Navis.Domain.Repository.Interfaces;

namespace Navis.Repository
{
    public class ModelRepository : BaseRepository<Model, ModelFilter>, IModelRepository
    {
    }
}
