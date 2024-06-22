using EntityLayer.WebApplication.ViewModels.CandidateVM;
using EntityLayer.WebApplication.ViewModels.ServiceVM;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services.WebApplication.Abstract;
using ServiceLayer.Services.WebApplication.Concrete;

namespace HRM.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CandidateController : Controller
    {
      private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        public async Task<IActionResult> GetCandidateList()
        {
            var candidateList = await _candidateService.GetAllListAsync();
            return View(candidateList);
        }

        [HttpGet]
        public IActionResult AddCandidate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCandidate(CandidateAddVM request)
        {
            await _candidateService.AddCandidateAsync(request);
            return RedirectToAction("GetCandidateList", "Candidate", new { Areas = ("Admin") });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCandidate(int id)
        {
            var candidate = await _candidateService.GetCandidateId(id);
            return View(candidate);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCandidate(CandidateUpdateVM request)
        {
            await _candidateService.UpdateCandidateAsync(request);
            return RedirectToAction("GetCandidateList", "Candidate", new { Areas = ("Admin") });
        }
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            await _candidateService.DeleteCandidateAsync(id);
            return RedirectToAction("GetCandidateList", "Candidate", new { Areas = ("Admin") });
        }

    }
}
