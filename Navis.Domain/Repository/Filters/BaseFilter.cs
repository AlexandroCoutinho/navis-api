using Navis.Domain.Repository.Filters.Interfaces;

namespace Navis.Domain.Repository.Filters
{
    public abstract class BaseFilter : IFilter
    {
        public string Id { get; set; } = "";
        public Paging Paging { get; set; } = new Paging();
        public Sorting Sorting { get; set; } = new Sorting();
    }
}
