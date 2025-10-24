using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController2 : ControllerBase
    {
        private readonly ICollegeRepo<Student> _studentRepository;
        private readonly ICollegeRepo<Course> _courseRepository;



        public CollegeController2(
            ICollegeRepo<Student> studentRepository,
            ICollegeRepo<Course> courseRepository)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        // Student Endpoints
        [HttpGet("students/all")]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var students = await _studentRepository.GetAll();
            return Ok(students);
        }

        [HttpGet("students/{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var student = await _studentRepository.getbyidAsync(id);

            if (student == null)
            {
                return NotFound($"Student with ID {id} not found");
            }

            return Ok(student);
        }

        [HttpGet("students/name/{name}")]
        public async Task<ActionResult<Student>> GetStudentByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be empty");
            }

            var student = await _studentRepository.getbynameAsync(name);

            if (student == null)
            {
                return NotFound($"Student with name '{name}' not found");
            }

            return Ok(student);
        }



        [HttpPost("students/create")]
        public async Task<ActionResult<int>> CreateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student cannot be null");
            }

            var result = await _studentRepository.create(student);
            return Ok(new { message = "Student created successfully", id = result });
        }

        [HttpPut("students/update")]
        public async Task<ActionResult<int>> UpdateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Student cannot be null");
            }

            var result = await _studentRepository.UpdateAsync(student);
            return Ok(new { message = "Student updated successfully", id = result });
        }

        [HttpDelete("students/delete/{id}")]
        public async Task<ActionResult<bool>> DeleteStudent(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var result = await _studentRepository.deletestudentAsync(id);

            if (!result)
            {
                return NotFound($"Student with ID {id} not found");
            }

            return Ok(new { message = "Student deleted successfully", success = true });
        }

        // Course Endpoints
        [HttpGet("courses/all")]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            var courses = await _courseRepository.GetAll();
            return Ok(courses);
        }

        [HttpGet("courses/{id}")]
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var course = await _courseRepository.getbyidAsync(id);

            if (course == null)
            {
                return NotFound($"Course with ID {id} not found");
            }

            return Ok(course);
        }

        [HttpGet("courses/name/{name}")]
        public async Task<ActionResult<Course>> GetCourseByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest("Name cannot be empty");
            }

            var course = await _courseRepository.getbynameAsync(name);

            if (course == null)
            {
                return NotFound($"Course with name '{name}' not found");
            }

            return Ok(course);
        }

        [HttpPost("courses/create")]
        public async Task<ActionResult<int>> CreateCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("Course cannot be null");
            }

            var result = await _courseRepository.create(course);
            return Ok(new { message = "Course created successfully", id = result });
        }

        [HttpPut("courses/update")]
        public async Task<ActionResult<int>> UpdateCourse([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("Course cannot be null");
            }

            var result = await _courseRepository.UpdateAsync(course);
            return Ok(new { message = "Course updated successfully", id = result });
        }

        [HttpDelete("courses/delete/{id}")]
        public async Task<ActionResult<bool>> DeleteCourse(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var result = await _courseRepository.deletestudentAsync(id);

            if (!result)
            {
                return NotFound($"Course with ID {id} not found");
            }

            return Ok(new { message = "Course deleted successfully", success = true });
        }
    }
}





