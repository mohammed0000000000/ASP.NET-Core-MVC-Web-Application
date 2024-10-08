using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TechWebApplication.Models.Auth;
using TechWebApplication.Models.Entities;
using TechWebApplication.Repo.EntityFramework.Data;
using TechWebApplication.Services.Contract;
using TechWebApplication.Services.Implementation;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Controllers
{
    public class UsersToCategoryController : Controller
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserCategoryServices userCategoryServices;

        public UsersToCategoryController(AppDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IUserCategoryServices userCategoryServices) {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.userCategoryServices = userCategoryServices;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index() {
            try {
                var items = await context.Category.ToListAsync();
                var res = mapper.Map<List<CategoryViewModel>>(items);
                return View(res);
            } catch (Exception ex) {
                throw;
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUsersForCategory([FromQuery] int categoryId) {
            try {
                UserCategoryListViewModel res = new UserCategoryListViewModel();
                res.Users = await GetAllUsers();
                res.UsersSelected = await GetSavedSelectedUsersForCategory(categoryId);
                return PartialView("_UsersListViewPartial", res);
            } catch (Exception ex) { throw; }
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
        public async Task<IActionResult> SaveSelectedUsers([Bind("CategoryId, UsersSelected")] UserCategoryListViewModel usersCategoryListViewModel) {
            List<UserCategory> usersSeletedForCategoryToAdd = null;
            if (usersCategoryListViewModel.UsersSelected is not null)
                usersSeletedForCategoryToAdd = await GetUsersForCategoryToAdd(usersCategoryListViewModel);
            var usersSeletedForCategoryToDelete = await GetUsersForCategoryToDelete(usersCategoryListViewModel.CategoryId);

            await userCategoryServices.UpdateUserCategory(usersSeletedForCategoryToDelete, usersSeletedForCategoryToAdd);
            usersCategoryListViewModel.Users = await GetAllUsers();
            return PartialView("_UserListViewPartial", usersCategoryListViewModel);
        }


        private async Task<List<UserCategory>> GetUsersForCategoryToAdd(UserCategoryListViewModel usersCategoryListViewModel) {
            var usersForCatgoryToAdd = (
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
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Courses() {
            var categoryToUser = new UserToCategoryViewModel();
            categoryToUser.Categories = await GetCategoriesThatHaveContent();
            var userId = userManager.GetUserAsync(User).Result?.Id;
            categoryToUser.CategoriesSelecetd = await GetCategoriesThatSavedForUser(userId);
            categoryToUser.UserId = userId;
            return View(categoryToUser);
        }
        private async Task<List<CategoryViewModel>> GetCategoriesThatHaveContent() {
            var categoriesWithContent = await (from category in context.Category
                                               join categoryItem in context.CategoryItem
                                               on category.Id equals categoryItem.CategoryId
                                               join content in context.Contents
                                               on categoryItem.Id equals content.CategoryItemId
                                               select new CategoryViewModel {
                                                   Id = category.Id,
                                                   Title = category.Title,
                                                   Description = category.Description,
                                                   ThumbnailImagePath = category.ThumbnailImagePath
                                               }).Distinct().ToListAsync();
            return categoriesWithContent;
        }
        private async Task<List<UserCategory>> GetCategoriesToDeleteForUser(string userId) {
            return await (
                from userCat in context.UserCategory
                where userCat.UserId == userId
                select new UserCategory { Id = userCat.Id, UserId = userCat.UserId, CategoryId = userCat.CategoryId }
            ).ToListAsync();
        }
        private List<UserCategory> GetCategoriesToAddForUser(string[] categoriesSelected, string userId) {
            return (from categoryId in categoriesSelected
                    select new UserCategory {
                        UserId = userId,
                        CategoryId = int.Parse(categoryId)
                    }).ToList();
        }
        private async Task<List<CategoryViewModel>> GetCategoriesThatSavedForUser(string userId) {
            return await (from userCat in context.UserCategory
                          where userCat.UserId == userId
                          select new CategoryViewModel {
                              Id = userCat.CategoryId
                          }
            ).ToListAsync();
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AssignCoursesToUser(string[] categoriesSelected) {
            var userId = userManager.GetUserAsync(User).Result?.Id;
            var userCategoriesToAdd = GetCategoriesToAddForUser(categoriesSelected, userId).ToList();
            var userCategoriesToDelete = await GetCategoriesToDeleteForUser(userId);

            await userCategoryServices.UpdateUserCategory(userCategoriesToDelete, userCategoriesToAdd);

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public async Task<string> AssignCourseToUser([FromQuery]int categoryId) {
            try {
                var userId = userManager.GetUserAsync(User).Result?.Id;
                if(userId is null){
                    return "Unauhorized";
                }
                var isTake = await (from userCat in context.UserCategory where userCat.UserId == userId && userCat.CategoryId == categoryId select new { Id = userCat.Id}).FirstOrDefaultAsync();
                if(isTake is null){
                    return "false";
                }
                await context.UserCategory.AddAsync(new UserCategory() { UserId = userId, CategoryId = categoryId });
                await context.SaveChangesAsync();
                return "true";
            } catch (Exception ex) {
                throw;
            }
        }
    }
}
