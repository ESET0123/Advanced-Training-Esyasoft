using Microsoft.AspNetCore.Mvc;

namespace CollegeApp_View.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
