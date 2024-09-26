using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Services.Contract
{
    public interface ICategoryItemServices
    {
        Task<CategoryItemViewModel> GetById(int id);
        Task<List<CategoryItemViewModel>> GetAll();
        Task<List<CategoryItemViewModel>> GetAll(int id);
        Task<CategoryItemViewModel> Create(CategoryItemViewModel categoryItemViewModel);
        Task<bool> Update(int id, CategoryItemViewModel categoryItemViewModel);
        Task<bool> Delete(int id);
    }
}
