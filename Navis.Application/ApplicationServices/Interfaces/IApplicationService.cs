using Navis.Application.ApplicationModels.PagedResult;

namespace Navis.Application.ApplicationServices.Interfaces
{
    public interface IApplicationService<TApplicationModel, TFilterApplicationModel>
    {
        Task<TApplicationModel> CreateAsync(TApplicationModel applicationModel);
        Task<TApplicationModel> ReadByIdAsync(string id);
        Task<PagedResultModel<TApplicationModel>> ReadPagedResultAsync(TFilterApplicationModel filter);
        Task<bool> UpdateAsync(string id);
        Task<bool> DeleteAsync(string id);
    }
}
