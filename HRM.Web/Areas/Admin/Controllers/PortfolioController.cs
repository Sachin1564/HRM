using EntityLayer.WebApplication.ViewModels.CategoryVM;
using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace HRM.Web.Areas.Admin.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> GetPortfolioList()
        {
            var portfolioList = await _portfolioService.GetAllListAsync();
            return View(portfolioList);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPortfolio(PortfolioAddVM request)
        {

            await _portfolioService.AddPortfoliotAsync(request);
            return RedirectToAction("GetPortfolioList", "Portfolio", new { Areas = ("Admin") });
        }
        [HttpGet]
        public async Task<IActionResult> UpdatePortfolio(int id)
        {
            var portfolio = await _portfolioService.GetPortfolioById(id);
            return View(portfolio);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePortfolio(PortfolioUpdateVM request)
        {
            await _portfolioService.UpdatePortfolioAsync(request);
            return RedirectToAction("GetPortfolioList", "Portfolio", new { Areas = ("Admin") });
        }
        public async Task<IActionResult> DeletePortfolio(int id)
        {
            await _portfolioService.DeletePortfolioAsync(id);
            return RedirectToAction("GetPortfolioList", "Portfolio", new { Areas = ("Admin") });
        }

    }
}
