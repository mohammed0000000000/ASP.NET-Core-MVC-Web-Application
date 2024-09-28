using Microsoft.AspNetCore.Mvc;
using TechWebApplication.Models.Entities;
using TechWebApplication.Services.Contract;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Controllers
{
    public class CategoryItemController: Controller
    {
        private readonly ICategoryItemServices services;
        public CategoryItemController(ICategoryItemServices services) {
            this.services = services;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int id) { // id => category id
            var res = await services.GetAll(id);
            ViewBag.categoryId = id;
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategoryItem(int categoryId) {
            ViewBag.categoryId = categoryId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategoryItem(CategoryItemViewModel categoryitemViewModel) {
            if (ModelState.IsValid) {
                categoryitemViewModel.DateTimeItemReleased = DateTime.Now;
                var res = await services.Create(categoryitemViewModel);
                if (res is not null)
                    return RedirectToAction("Index",new { id = res.CategoryId});
            }
            return View(categoryitemViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategoryItem(int id) {
            var item = await services.GetById(id);
            var res = await services.Delete(id);
            return RedirectToAction("Index", new {id = item.CategoryId});
        }


        [HttpGet]
        public async Task<IActionResult> UpdateCategoryItem(int id) {
            var res = await services.GetById(id);
            return View(res);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategoryItem(int id, CategoryItemViewModel categoryItemViewModel) {
            if (ModelState.IsValid) {
                var res = await services.Update(id, categoryItemViewModel);
                return res ? RedirectToAction("Index", new { id = categoryItemViewModel.CategoryId }) : View(categoryItemViewModel);
            }
            return View(ModelState);
        }
        [HttpGet]
        public async Task<IActionResult> DetailCategoryitem(int id) {
            var res = await services.GetById(id);
            return View(res);
        }
    }
}
