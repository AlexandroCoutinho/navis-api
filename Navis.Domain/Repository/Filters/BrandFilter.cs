using Navis.Domain.Entities;
using Navis.Domain.Repository.Filters.Interfaces;

namespace Navis.Domain.Repository.Filters
{
    public class BrandFilter : BaseFilter, IFilter
    {
        public string Name { get; set; } = "";
    }
}
