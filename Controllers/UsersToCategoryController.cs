using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechWebApplication.Models.Auth;
using TechWebApplication.Models.Entities;
using TechWebApplication.Repo.EntityFramework.Data;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Controllers
{
    public class UsersToCategoryController : Controller
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        public UsersToCategoryController(AppDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(){
            try {
                var items = await context.Category.ToListAsync();
                var res = mapper.Map<List<CategoryViewModel>>(items);
                return View(res);
            } catch (Exception ex) {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersForCategory([FromQuery]int categoryId) {
            try {
                UserCategoryListViewModel res = new UserCategoryListViewModel();
                res.Users = await GetAllUsers();
                res.UsersSelected = await GetSavedSelectedUsersForCategory(categoryId);
                return PartialView("_UsersListViewPartial", res);
            } catch (Exception ex) 
            { throw; }
        }
        public async Task<List<UserViewModel>> GetSavedSelectedUsersForCategory(int categoryId) {
            return await (
            from userToCategory in context.UserCategory
            where userToCategory.CategoryId == categoryId
            select new UserViewModel {
                Id = userToCategory.UserId
            }).ToListAsync();
        }
        private async Task<List<UserViewModel>> GetAllUsers() {
            var allUsers = await (from user in context.Users
                                  select new UserViewModel {
                                      Id = user.Id,
                                      UserName = user.UserName,
                                      FirstName = user.FirstName,
                                      LastName = user.LastName
                                  }
                                              ).ToListAsync();
            return allUsers;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveSelectedUsers([Bind("CategoryId, UsersSelected")]UserCategoryListViewModel usersCategoryListViewModel) {
            List<UserCategory> usersSeletedForCategoryToAdd = null;
            if(usersCategoryListViewModel.UsersSelected is not null)
                usersSeletedForCategoryToAdd = await GetUsersForCategoryToAdd(usersCategoryListViewModel);
            var usersSeletedForCategoryToDelete = await GetUsersForCategoryToDelete(usersCategoryListViewModel.CategoryId);
            using (var dbContextTransaction = await context.Database.BeginTransactionAsync()) {
                try {
                    context.UserCategory.RemoveRange(usersSeletedForCategoryToDelete);
                    await context.SaveChangesAsync();

                    if (usersSeletedForCategoryToAdd is not null){
                        await context.UserCategory.AddRangeAsync(usersSeletedForCategoryToAdd);
                        await context.SaveChangesAsync();
                    }
                    await dbContextTransaction.CommitAsync();
                } catch (Exception ex) {
                    await dbContextTransaction.DisposeAsync();
                }
            }
            usersCategoryListViewModel.Users = await GetAllUsers();
            return PartialView("_UserListViewPartial", usersCategoryListViewModel);
        }


        private async Task<List<UserCategory>> GetUsersForCategoryToAdd(UserCategoryListViewModel usersCategoryListViewModel) {
            var usersForCatgoryToAdd =  (
                from userCategory in usersCategoryListViewModel.UsersSelected
                select new UserCategory { CategoryId = usersCategoryListViewModel.CategoryId, UserId = userCategory.Id }
            ).ToList();
            return await Task.FromResult(usersForCatgoryToAdd);
        }
        private async Task<List<UserCategory>> GetUsersForCategoryToDelete(int categoryId) {
            var usersForCatgoryToDelete = await (
                from userCategory in context.UserCategory
                where userCategory.CategoryId == categoryId
                select new UserCategory { Id = userCategory.Id, CategoryId = userCategory.CategoryId, UserId = userCategory.UserId }
            ).ToListAsync();
            return usersForCatgoryToDelete;
        }
    }
}
