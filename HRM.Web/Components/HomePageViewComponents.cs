using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace HRM.Web.Components
{
    public class HomePageViewComponents  : ViewComponent
    {
        private readonly HomePageService _homePageService;

        public HomePageViewComponents(HomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var homePageListForUI = await _homePageService.GetAllListForUIAsync();
            return View(homePageListForUI);
        }

    }
}
