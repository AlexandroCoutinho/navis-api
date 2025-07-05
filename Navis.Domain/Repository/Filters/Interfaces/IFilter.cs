using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Repository.Filters.Interfaces
{
    public interface IFilter
    {
        public string Id { get; set; }
        Paging Paging { get; set; }
        Sorting Sorting { get; set; }
    }
}
