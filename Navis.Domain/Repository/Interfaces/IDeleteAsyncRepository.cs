namespace Navis.Domain.Repository.Interfaces
{
    public interface IDeleteAsyncRepository
    {
        Task<bool> DeleteAsync(string id, bool soft);
    }
}
