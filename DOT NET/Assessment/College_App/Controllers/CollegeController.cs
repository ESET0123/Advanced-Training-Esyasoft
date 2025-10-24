using collage_app.Mylogger;
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : Controller
    {
        private readonly IMylogger _mylogger;
        private readonly IStudentRepository _IstudentRepository;

        public CollegeController(IMylogger logger, IStudentRepository studentRepository)
        {
            _mylogger = logger;
            _IstudentRepository = studentRepository;
        }

       
        [HttpGet]
        [Route("All")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<Student>>> getStudents()
        {
            var students = await _IstudentRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Student>> getstudentbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var student = await _IstudentRepository.GetstudentbyidAsync(id);
            if (student == null)
            {
                return NotFound($"Id {id} not found");
            }
            return Ok(student);
        }

        [HttpGet("{name:Alpha}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task< ActionResult<Student>> getstudentbyname(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            var student =  await _IstudentRepository.GetstudentbynameAsync(name);
            if (student == null)
            {
                return NotFound($"{name} not found");

            }
            return Ok(student);
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> CreateStudents([FromBody] Student model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            Student studentnew = new Student
            {
                name = model.name,
                age = model.age,
                email = model.email
            };
            var studentId = await _IstudentRepository.CreatestudentAsync(studentnew);
            return Ok(studentId);

        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<bool>> UpdateStudent([FromBody] Student model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var existingstudent = await _IstudentRepository.GetstudentbyidAsync(model.studentID);
            if (existingstudent == null)
            {
                return NotFound();
            }

            Student studentnew = new Student
            {
                studentID = model.studentID,
                name = model.name,
                age = model.age,
                email = model.email
            };          

            var result = await _IstudentRepository.UpdatestudentAsync(existingstudent,studentnew);
            if(result==1)
                return Ok(true);
            else
                return NotFound();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<bool>> deletestudent(int id)
        {
            return await _IstudentRepository.DeletestudentAsync(id);
        }
    }
}
