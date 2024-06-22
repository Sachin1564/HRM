using EntityLayer.WebApplication.ViewModels.SocialMediaVM;
using EntityLayer.WebApplication.ViewModels.TeamVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace HRM.Web.Areas.Admin.Controllers
{
    public class TeamController : Controller
    {
       private readonly ITeamService _service;

        public TeamController(ITeamService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetTeamList()
        {
            var teamList = await _service.GetAllListAsync();
            return View(teamList);
        }

        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTeam(TeamAddVM request)
        {
            await _service.AddTeamtAsync(request);
            return RedirectToAction("GetTeamList", "Team", new { Areas = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTeam(int id)
        {
            var team = await _service.GetTeamById(id);
            return View(team);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTeam(TeamUpdateVM request)
        {
            await _service.UpdateTeamAsync(request);
            return RedirectToAction("GetTeamList", "Team", new { Areas = ("Admin") });
        }
        public async Task<IActionResult> DeleteTeam(int id)
        {
            await _service.DeleteTeamAsync(id);
            return RedirectToAction("GetTeamList", "Team", new { Areas = ("Admin") });
        }
    }
}
