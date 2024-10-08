using TechWebApplication.Models.Entities;

namespace TechWebApplication.Services.Contract
{
    public interface IUserCategoryServices
    {
        Task UpdateUserCategory(List<UserCategory> userCategoriesToDelete, List<UserCategory> userCategoriesToAdd);
    }
}
