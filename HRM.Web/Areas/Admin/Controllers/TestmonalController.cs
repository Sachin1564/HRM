using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.TeamVM;
using EntityLayer.WebApplication.ViewModels.TestmonalVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace HRM.Web.Areas.Admin.Controllers
{
    public class TestmonalController : Controller
    {
        private readonly ITestmonalService _testmonalService;

        public TestmonalController(ITestmonalService testmonalService)
        {
            _testmonalService = testmonalService;
        }
        public async Task<IActionResult> GetTestmonalList()
        {
            var testmonalList = await _testmonalService.GetAllListAsync();
            return View(testmonalList);
        }
        [HttpGet]
        public IActionResult AddTestmonal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestmonal(TestmonalAddVM request)
        {
            await _testmonalService.AddTestmonaltAsync(request);
            return RedirectToAction("GetTestmonalList", "Testmonal", new { Areas = ("Admin") });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTestmonal(int id)
        {
            var testmonal = await _testmonalService.GetTestmonalById(id);
            return View(testmonal);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestmonal(TestmonalUpdateVM request)
        {
            await _testmonalService.UpdateTestmonalAsync(request);
            return RedirectToAction("GetTestmonalList", "Testmonal", new { Areas = ("Admin") });
        }
    }
}
