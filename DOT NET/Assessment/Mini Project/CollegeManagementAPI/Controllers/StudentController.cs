using CollegeManagementAPI.Models;
using CollegeManagementAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpGet]
        [Route("AllStudents")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var students = await _studentRepo.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var student = await _studentRepo.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound($"Id {id} not found");
            }
            return Ok(student);
        }

        [HttpGet("{name:Alpha}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Student>> GetStudentByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            var student = await _studentRepo.GetByNameAsync(name);
            if (student == null)
            {
                return NotFound($"Name {name} not found");
            }
            return Ok(student);
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<int>> CreateStudent([FromBody] Student model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            Student studentNew = new Student
            {
                RollNumber = model.RollNumber,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                CourseId = model.CourseId
            };
            await _studentRepo.AddAsync(studentNew);
            return Ok();
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateStudent([FromBody] Student model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var existingStudent = await _studentRepo.GetByIdAsync(model.StudentId);
            if (existingStudent == null)
            {
                return NotFound();
            }

            Student studentUpdate = new Student
            {
                StudentId = model.StudentId,
                RollNumber = model.RollNumber,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                CourseId = model.CourseId
            };

            await _studentRepo.UpdateAsync(studentUpdate);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            await _studentRepo.DeleteAsync(id);
            return Ok();
        }
    }
}
