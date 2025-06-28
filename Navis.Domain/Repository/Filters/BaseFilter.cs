using Navis.Domain.Entities.Interfaces;
using Navis.Domain.Repository.Filters.Interfaces;

namespace Navis.Domain.Repository.Filters
{
    public abstract class BaseFilter<T> : IFilter<T> where T : IEntity
    {
        public string Id { get; set; } = "";
        public Paging Paging { get; set; } = new Paging();
        public Sorting Sorting { get; set; } = new Sorting();
    }
}
