using Microsoft.AspNetCore.Mvc;

namespace CollegeApp_View.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
