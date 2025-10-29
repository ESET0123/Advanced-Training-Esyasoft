using CollegeManagementAPI.Models;
using CollegeManagementAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepo;

        public CourseController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet]
        [Route("AllCourse")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<List<Course>>> getCourses()
        {
            var courses = await _courseRepo.GetAllAsync();
            return Ok(courses);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Course>> getcoursebyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var student = await _courseRepo.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound($"Id {id} not found");
            }
            return Ok(student);
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> CreateCourses([FromBody] Course model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            Course coursenew = new Course
            {
                CourseCode = model.CourseCode,
                CourseName = model.CourseName,
                Department = model.Department,
                Semester = model.Semester
            };
            await _courseRepo.AddAsync(coursenew);
            return Ok();

        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateCourse([FromBody] Course model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var existingcourse = await _courseRepo.GetByIdAsync(model.CourseId);
            if (existingcourse == null)
            {
                return NotFound();
            }

            Course coursenew = new Course
            {
                CourseId = model.CourseId,
                CourseCode = model.CourseCode,
                CourseName = model.CourseName,
                Department = model.Department,
                Semester = model.Semester
            };

            await _courseRepo.UpdateAsync(coursenew);
            //if (result == 1)
            return Ok();
            //else
            //    return NotFound();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> deletestudent(int id)
        {
            await _courseRepo.DeleteAsync(id);
            return Ok();
        }
    }
}
