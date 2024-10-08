using TechWebApplication.Models.Entities;
using TechWebApplication.Repo.EntityFramework.Data;
using TechWebApplication.Services.Contract;

namespace TechWebApplication.Services.Implementation
{
    public class UserCatgoryServices : IUserCategoryServices
    {
    private readonly AppDbContext context;
        public UserCatgoryServices(AppDbContext context) {
            this.context = context;
        }
        public async Task UpdateUserCategory(List<UserCategory> userCategoriesToDelete, List<UserCategory> userCategoriesToAdd) {
            using (var transaction = context.Database.BeginTransaction()) {
                try {
                    context.UserCategory.RemoveRange(userCategoriesToDelete);
                    await context.SaveChangesAsync();
                    if (userCategoriesToAdd is not null) {
                        await context.UserCategory.AddRangeAsync(userCategoriesToAdd);
                        await context.SaveChangesAsync();
                    }
                    await transaction.CommitAsync();
                } catch (Exception ex) {
                    await transaction.DisposeAsync();
                }
            }
        }
    }
}
