using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Entities
{
    public class Model : IEntity
    {
        public string Id { get; set; } = "";
        public bool IsDeleted { get; set; } = false;
        public string Name { get; set; } = "";
        
    }
}
