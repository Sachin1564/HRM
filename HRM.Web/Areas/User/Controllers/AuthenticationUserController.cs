using Microsoft.AspNetCore.Mvc;

namespace HRM.Web.Areas.User.Controllers
{
    public class AuthenticationUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
