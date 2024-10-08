using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TechWebApplication.Models;
using TechWebApplication.Models.Auth;
using TechWebApplication.Models.Entities;
using TechWebApplication.Repo.EntityFramework.Data;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, SignInManager<ApplicationUser> signManager, UserManager<ApplicationUser>userManager) {
            _logger = logger;
            _context = context;
            _signManager = signManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index() {
            CategoryDetailsViewModel categoryDetailsModel = new CategoryDetailsViewModel();
            var categories = await GetCategoriesThatHaveContent();
            categoryDetailsModel.Categories = categories;
            return View(categoryDetailsModel);
        }
        public async Task<IActionResult> UserCourses(){
            IEnumerable<CategoryItemDetailsViewModel> categoryItemDetailsModels = null;
            IEnumerable<GroupedCategoryItemsByCategoryViewModels> groupedCategoryItemsByCategoryModels = null;

            CategoryDetailsViewModel categoryDetailsModel = new CategoryDetailsViewModel();

            if (_signManager.IsSignedIn(User)) {
                var user = await _userManager.GetUserAsync(User);

                if (user != null) {
                    categoryItemDetailsModels = await GetCategoryItemDetailsForUser(user.Id);
                    groupedCategoryItemsByCategoryModels = await GetGroupedCategoryItemsByCategory(categoryItemDetailsModels);

                    categoryDetailsModel.GroupedCategoryItemsByCategoryViewModels = groupedCategoryItemsByCategoryModels;
                }

            }
            return View("UserLibrary",categoryDetailsModel);
        }
        private async Task<List<CategoryViewModel>> GetCategoriesThatHaveContent() {
            var categoriesWithContent = await (from category in _context.Category
                                               join categoryItem in _context.CategoryItem
                                               on category.Id equals categoryItem.CategoryId
                                               join content in _context.Contents
                                               on categoryItem.Id equals content.CategoryItemId
                                               select new CategoryViewModel {
                                                   Id = category.Id,
                                                   Title = category.Title,
                                                   Description = category.Description,
                                                   ThumbnailImagePath = category.ThumbnailImagePath
                                               }).Distinct().ToListAsync();
            return categoriesWithContent;
        }

        private async Task<IEnumerable<GroupedCategoryItemsByCategoryViewModels>> GetGroupedCategoryItemsByCategory(IEnumerable<CategoryItemDetailsViewModel> categoryItemDetailsModels) {
            return await Task.FromResult(from item in categoryItemDetailsModels
                   group item by item.CategoryId into g
                   select new GroupedCategoryItemsByCategoryViewModels {
                       Id = g.Key,
                       Title = g.Select(c => c.CategoryTitle).FirstOrDefault(),
                       Items = g
                   });
        }

        private async Task<IEnumerable<CategoryItemDetailsViewModel>> GetCategoryItemDetailsForUser(string userId) {
            return await (from catItem in _context.CategoryItem
                          join category in _context.Category
                          on catItem.CategoryId equals category.Id
                          join content in _context.Contents
                          on catItem.Id equals content.CategoryItem.Id
                          join userCat in _context.UserCategory
                          on category.Id equals userCat.CategoryId
                          join mediaType in _context.MediType
                          on catItem.MediaTypeId equals mediaType.Id
                          where userCat.UserId == userId
                          select new CategoryItemDetailsViewModel {
                              CategoryId = category.Id,
                              CategoryTitle = category.Title,
                              CategoryItemId = catItem.Id,
                              CategoryItemTitle = catItem.Title,
                              CategoryItemDescription = catItem.Description,
                              MediaImagePath = mediaType.ThumbnailImagePath
                          }).ToListAsync();
        }
        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
