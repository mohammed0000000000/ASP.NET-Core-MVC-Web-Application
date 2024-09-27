using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Services.Contract
{
    public interface IContentServices
    {
        Task<ContentViewModel>GetById(int id);  
        Task<ContentViewModel> GetByItemId(int itemId);
        Task<bool> Delete(int id);
        Task<ContentViewModel> Update(ContentViewModel contentViewModel);
        Task<ContentViewModel>Create(ContentViewModel contentViewModel);
    }
}
