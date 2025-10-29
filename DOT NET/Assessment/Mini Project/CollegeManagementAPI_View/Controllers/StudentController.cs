using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementAPI_View.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Student()
        {
            return View();
        }
    }
}
