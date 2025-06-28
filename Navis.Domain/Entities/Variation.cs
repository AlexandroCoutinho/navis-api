using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Entities
{
    public class Variation : IEntity
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public bool LimitedEdition { get; set; } = false;

        public decimal Weight { get; set; }

        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
    }
}
