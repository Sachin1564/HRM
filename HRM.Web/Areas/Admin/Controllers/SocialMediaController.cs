using EntityLayer.WebApplication.Entities;
using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using EntityLayer.WebApplication.ViewModels.SocialMediaVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace HRM.Web.Areas.Admin.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public async Task<IActionResult> GetSocialMediaList()
        {
            var socialmediaList = await _socialMediaService.GetAllListAsync();
            return View(socialmediaList);
        }
        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSocialMedia(SocialMediaAddVM request)
        {

            await _socialMediaService.AddSocialMediatAsync(request);
            return RedirectToAction("GetSocialMediaList", "SocialMedia", new { Areas = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var socialmedia = await _socialMediaService.GetSocialMediaById(id);
            return View(socialmedia);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(SocialMediaUpdateVM request)
        {
            await _socialMediaService.UpdateSocialMediaAsync(request);
            return RedirectToAction("GetSocialMediaList", "SocialMedia", new { Areas = ("Admin") });
        }
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _socialMediaService.DeleteSocialMediaAsync(id);
            return RedirectToAction("GetSocialMediaList", "SocialMedia", new { Areas = ("Admin") });
        }

    }
}
