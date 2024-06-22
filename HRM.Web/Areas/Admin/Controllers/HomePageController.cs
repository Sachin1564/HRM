using EntityLayer.WebApplication.ViewModels.CategoryVM;
using EntityLayer.WebApplication.ViewModels.HomePageVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace HRM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageController : Controller
    {
        private readonly IHomePageService _homepageService;

        public HomePageController(IHomePageService homepageService)
        {
            _homepageService = homepageService;
        }

        public async Task<IActionResult> GetHomePageList()
        {
            var homepageList = await _homepageService.GetAllListAsync();
            return View(homepageList);
        }

        [HttpGet]
        public IActionResult AddHomePage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHomePage(HomePageAddVM request)
        {

            await _homepageService.AddHomePagetAsync(request);
            return RedirectToAction("GetHomePageList", "HomePage", new { Areas = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateHomePage(int id)
        {
            var homepage = await _homepageService.GetHomePageById(id);
            return View(homepage);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHomePage(HomePageUpdateVM request)
        {
            await _homepageService.UpdateHomePageAsync(request);
            return RedirectToAction("GetHomePageList", "HomePage", new { Areas = ("Admin") });
        }

        public async Task<IActionResult> DeleteHomePage(int id)
        {
            await _homepageService.DeleteHomePageAsync(id);
            return RedirectToAction("GetHomePageList", "HomePage", new { Areas = ("Admin") });
        }

    }
}
