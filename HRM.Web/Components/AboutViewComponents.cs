using EntityLayer.WebApplication.ViewModels.AboutVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;

namespace HRM.Web.Components
{
    public class AboutViewComponents : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public AboutViewComponents(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aboutListForUI = await _aboutService.GelAllListForUIAsync();
            return View(aboutListForUI);
        }
    }
}
