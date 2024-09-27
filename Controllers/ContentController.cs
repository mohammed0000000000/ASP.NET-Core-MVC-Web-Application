using Microsoft.AspNetCore.Mvc;
using TechWebApplication.Services.Contract;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Controllers
{
    public class ContentController : Controller
    {
        private readonly IContentServices contentServices;
        private readonly ICategoryItemServices categoryItemServices;
        public ContentController(IContentServices contentServices, ICategoryItemServices categoryItemServices) {
            this.contentServices = contentServices;
            this.categoryItemServices = categoryItemServices;
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id){
            var categoryItem = await categoryItemServices.GetById(id);
            var categoryItemMediaType = categoryItem.MediaTypeId;
            ViewBag.CategoryItemId = id;
            ViewBag.CategoryItemMediaType = (categoryItemMediaType == 1 ? "Video" : "Article");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContentViewModel contentViewModel) {
            contentViewModel.Id = default;
            if (ModelState.IsValid) {
                var res = await contentServices.Create(contentViewModel);
                if (res is not null) {
                    var categoryId = (await categoryItemServices.GetById(res.CategoryItemId)).CategoryId;
                    return RedirectToAction("Index", "CategoryItem", new { id = categoryId });
                }
            }
            return View(contentViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id){
            var content = await contentServices.GetById(id);
            var categoryItem = await categoryItemServices.GetById(content.CategoryItemId);
            var categoryItemMediaType = categoryItem.MediaTypeId;
            ViewBag.CategoryItemId = id;
            ViewBag.CategoryItemMediaType = (categoryItemMediaType == 1 ? "Video" : "Article");
            return View(content);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(ContentViewModel contentVeiwModel) {
            if (ModelState.IsValid) {
                var res = await contentServices.Update(contentVeiwModel);
                if(res is not null){
                    var categoryId = (await categoryItemServices.GetById(res.CategoryItemId)).CategoryId;
                    return RedirectToAction("Index", "CategoryItem", new { id = categoryId });
                }
            }
            return View(contentVeiwModel);
        }
    }
}
