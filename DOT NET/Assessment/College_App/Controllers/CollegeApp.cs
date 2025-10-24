using collage_app.Mylogger;
using CollegeApp.Data;
using CollegeApp.Data.Repository;
using CollegeApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class logme : ControllerBase
    //{
    //    private readonly IMylogger _mylogger;


    //    public logme(IMylogger mylogger)
    //    {
    //        _mylogger = mylogger;
    //    }


    //    [HttpGet]
    //    public ActionResult index()
    //    {
    //        _mylogger.Log("index method started");


    //        return Ok();
    //    }

    //}

    [Route("api/[controller]")]
    [ApiController]
    public class CollegeApp : ControllerBase
    {
        private readonly IMylogger _mylogger;
        private readonly CollegeDBContext _dbContext;
        //private readonly IStudentRepository _studentRepository;

        public CollegeApp(IMylogger logger, CollegeDBContext dbContext)
        {
            _mylogger = logger;
            _dbContext = dbContext;
        }

        //public CollegeApp(IStudentRepository studentRepository)
        //{
        //    _studentRepository = studentRepository;
        //}

        [HttpGet]
        [Route("All")]

        //public IEnumerable<Student> getStudents()
        //{
        //    return collegeRepository.students;
        //}
        public ActionResult<IEnumerable<studentDTO>> getStudents()
        {
            //var students = _dbContext.Students.Select(s => new studentDTO()
            //{
            //    studentID = s.studentID,
            //    name = s.name,
            //    age = s.age,
            //    email = s.email
            //});
            var students = _dbContext.Students.ToList();
            return Ok(students);

        }

         //[HttpGet]
        //[Route("{id:int}")]  //[Route("{id:int}", Name = "getstudentbyid")]
        [HttpGet("{id:int}", Name = "getstudentbyid")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Student> getstudentbyid(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var students = _dbContext.Students.Where(n => n.studentID == id).FirstOrDefault();
            var studentDTO = new studentDTO()
            {
                //studentID = students.studentID,
                name = students.name,
                age = students.age,
                email = students.email
            };
            if (studentDTO == null)
            {
                return NotFound($"Id {id} not found");
            }
            return Ok(studentDTO);
        }

        [HttpGet("{name:Alpha}", Name = "getstudentbyname")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Student> getstudentbyname(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            var students = _dbContext.Students.Where(n => n.name == name).FirstOrDefault();
            var studentDTO = new studentDTO()
            {
                //studentID = students.studentID,
                name = students.name,
                age = students.age,
                email = students.email
            };
            //var studentDTO =  collegeRepository.students.Where(n => n.name == name).Select(s => new studentDTO()
            //{
            ////    studentID = s.studentID,
            //    name = s.name,
            //    age = s.age,
            //    email = s.email
            //}).FirstOrDefault();
            if (studentDTO == null)
            {
                return NotFound($"{name} not found");

            }
            return Ok(studentDTO);
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<bool> deletestudent(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var deleting = _dbContext.Students.Where(n => n.studentID == id).FirstOrDefault();
            if(deleting == null)
            {
                return NotFound();
            }
            _dbContext.Students.Remove(deleting);
            _dbContext.SaveChanges();
            //await _dbContext.SaveChanges();
            return Ok(true);
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<studentDTO> CreateStudent([FromBody]studentDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            //int newid = _dbContext.Students.LastOrDefault().studentID + 1;

            Student studentnew = new Student
            {
                //studentID = newid,
                name = model.name,
                age = model.age,
                email = model.email
            };
            _dbContext.Students.Add(studentnew); 
            _dbContext.SaveChanges();
            return Ok(studentnew);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult UpdateStudent([FromBody]studentDTO model)
        {
            if (model == null || model.studentID == 0)
            {
                return BadRequest();
            }
            var existingStudent = _dbContext.Students.Where(s=>s.studentID == model.studentID).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound("Student id not found");
            }
            existingStudent.studentID = model.studentID;
            existingStudent.name = model.name;
            existingStudent.age = model.age;
            existingStudent.email = model.email;

            _dbContext.SaveChanges();

            return NoContent();
        }
        [HttpPatch]
        [Route("{id:int}UpdatePartial")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult UpdateStudentPartial(int id, [FromBody] JsonPatchDocument<studentDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }
            var existingStudent = _dbContext.Students.Where(s => s.studentID == id).FirstOrDefault();
            if (existingStudent == null)
            {
                return NotFound("Student id not found");
            }
            var studentDto = new studentDTO()
            {
                studentID = existingStudent.studentID,
                name = existingStudent.name,
                age = existingStudent.age,
                email = existingStudent.email,
            };
            patchDocument.ApplyTo(studentDto, ModelState);

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            //existingStudent.studentID = model.studentID;
            existingStudent.name = studentDto.name;
            existingStudent.age = studentDto.age;
            existingStudent.email = studentDto.email;

            _dbContext.SaveChanges();
            return NoContent();
        }
        
    }
}
