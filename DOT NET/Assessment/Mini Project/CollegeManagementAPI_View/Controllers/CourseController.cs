using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementAPI_View.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Course()
        {
            return View();
        }
    }
}
