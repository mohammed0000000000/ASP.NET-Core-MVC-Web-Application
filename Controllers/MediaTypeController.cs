using Microsoft.AspNetCore.Mvc;
using TechWebApplication.Services.Contract;
using TechWebApplication.Services.ViewModel;

namespace TechWebApplication.Controllers
{
    public class MediaTypeController : Controller
    {
        private readonly IMediaTypeServices mediaTypeServices;
        public MediaTypeController(IMediaTypeServices mediaTypeServices) {
            this.mediaTypeServices = mediaTypeServices;
        }
        [HttpGet]
        public async Task<IActionResult> Index() {
            var res = await mediaTypeServices.GetAll();
            return View(res);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id){
            var res = await mediaTypeServices.GetById(id);
            return View(res);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(MediaTypeViewModel viewModel) {
            var res = await mediaTypeServices.Update(viewModel);
            return res ? RedirectToAction("Index") : View(viewModel);
        }

    }
}
