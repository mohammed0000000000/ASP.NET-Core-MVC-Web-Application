using TechWebApplication.Services.ViewModel.Auth;

namespace TechWebApplication.Services.Contract
{
    public interface ICategoryServices
    {
        Task<CategoryViewModel> GetById(int id);
        Task<List<CategoryViewModel>> GetAll();
        Task<CategoryViewModel> Create(CategoryViewModel categoryViewModel);
        Task<bool> Update(int id, CategoryViewModel categoryViewModel);
        Task<bool> Delete(int id);
    }
}
