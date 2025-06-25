using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Entities
{
    public class Brand : IEntity
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
    }
}
