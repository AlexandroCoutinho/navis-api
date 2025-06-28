using Navis.Domain.Repository.Filters;

namespace Navis.Application.Models.Filters
{
    public abstract class BaseFilterModel
    {
        public string Id { get; set; } = "";
        public PagingModel Paging { get; set; } = new PagingModel();
        public SortingModel Sorting { get; set; } = new SortingModel();
    }
}
