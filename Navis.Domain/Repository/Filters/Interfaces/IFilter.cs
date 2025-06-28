using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Repository.Filters.Interfaces
{
    public interface IFilter<T> where T : IEntity
    {
        public string Id { get; set; }
        Paging Paging { get; set; }
        Sorting Sorting { get; set; }
    }
}
