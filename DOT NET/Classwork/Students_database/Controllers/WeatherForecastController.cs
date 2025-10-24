using Microsoft.AspNetCore.Mvc;
using Students_database.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Students_database.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly CollegeContext _dbcontext;

        //private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController( CollegeContext mycontext)
        {
            //_logger = logger;
            _dbcontext = mycontext;
        }

        [HttpGet(Name = "GetStudent")]
        public IEnumerable<Course> Get()
        {
            return _dbcontext.Courses.ToList();
        }
    }
}
