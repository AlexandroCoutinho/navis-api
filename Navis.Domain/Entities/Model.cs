using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Entities
{
    public class Model : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
