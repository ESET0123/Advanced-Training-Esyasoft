using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementAPI_View.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
