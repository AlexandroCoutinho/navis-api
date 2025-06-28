using Navis.Domain.Entities.Interfaces;

namespace Navis.Domain.Repository.PagedResult
{
    public class PagedResult<T> where T : IEntity
    {
        public IList<T> Data { get; set; } = new List<T>();
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; } = 1; 
        public long TotalItems { get; set; } = 0;
        public int TotalPages { get; set; } = 0;
    }
}
