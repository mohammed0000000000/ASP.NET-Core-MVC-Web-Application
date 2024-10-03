using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TechWebApplication.Services.Contract;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ICategoryServices services;
        public CategoryController(ICategoryServices services) {
            this.services = services;
        }
        [HttpGet]
        public async Task<IActionResult> Index() {
            var categories = await services.GetAll();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCategory() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CategoryViewModel categoryViewModel) {
            if (ModelState.IsValid) {
                var res = await services.Create(categoryViewModel);
                if (res is not null)
                    return RedirectToAction("Index");
            }
            return View(categoryViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id) {
            var res = await services.Delete(id);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id) {
            var res = await services.GetById(id);
            return View(res);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(int id, CategoryViewModel categoryViewModel) {
            if (ModelState.IsValid) {
                var res = await services.Update(id, categoryViewModel);
                return res ? RedirectToAction("Index") : View(categoryViewModel);
            }
            return View(ModelState);
        }
        [HttpGet]
        public async Task<IActionResult> DetailCategory(int id){
            var res = await services.GetById(id);
            return View(res);
        }

    
    }
}
