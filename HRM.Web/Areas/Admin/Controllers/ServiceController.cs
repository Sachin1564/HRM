using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using EntityLayer.WebApplication.ViewModels.ServiceVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace HRM.Web.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        public async Task<IActionResult> GetServiceList()
        {
            var serviceList = await _serviceService.GetAllListAsync();
            return View(serviceList);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddService(ServiceAddVM request)
        {

            await _serviceService.AddServiceAsync(request);
            return RedirectToAction("GetServiceList", "Service", new { Areas = ("Admin") });
        }
        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var service = await _serviceService.GetServiceId(id);
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateService(ServiceUpdateVM request)
        {
            await _serviceService.UpdateServiceAsync(request);
            return RedirectToAction("GetServiceList", "Service", new { Areas = ("Admin") });
        }
        public async Task<IActionResult> DeleteService(int id)
        {
            await _serviceService.DeleteServiceAsync(id);
            return RedirectToAction("GetServiceList", "Service", new { Areas = ("Admin") });
        }

    }
}
