using collage_app.Mylogger;
using CollegeApp.Data;
using CollegeApp.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeApp.Controllers
{
   
        [Route("api/[controller]")]
        [ApiController]
        public class CourseApp : ControllerBase
        {
            //private readonly IMylogger _mylogger;
            private readonly CollegeDBContext _dbContext;

            public CourseApp( CollegeDBContext dbContext)
            {
                _dbContext = dbContext;
            }

            [HttpGet]
            [Route("All")]

            //public IEnumerable<Course> getCourses()
            //{
            //    return courseRepository.courses;
            //}
            public async Task<ActionResult<IEnumerable<CourseDTO>>> getCoursesAsync()
            {
                //var courses = _dbContext.Courses.Select(s => new CourseDTO()
                //{
                //    courseID = s.courseID,
                //    name = s.name,
                //    age = s.age,
                //    email = s.email
                //}).ToListAsync();
                var courses = await _dbContext.Courses.ToListAsync();
                return Ok(courses);

            }

            //[HttpGet]
            //[Route("{id:int}")]  //[Route("{id:int}", Name = "getcoursebyid")]
            [HttpGet("{id:int}", Name = "getcoursebyid")]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]
            [ProducesResponseType(404)]
            public ActionResult<Course> getcoursebyid(int id)
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var courses = _dbContext.Courses.Where(n => n.Id == id).FirstOrDefault();
                var CourseDTO = new CourseDTO()
                {
                    //courseID = courses.courseID,
                    Id = courses.Id,
                    Name = courses.Name,
                    Description = courses.Description
                };
                if (CourseDTO == null)
                {
                    return NotFound($"Id {id} not found");
                }
                return Ok(CourseDTO);
            }

            [HttpGet("{name:Alpha}", Name = "getcoursebyname")]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]
            [ProducesResponseType(404)]
            public ActionResult<Course> getcoursebyname(string name)
            {
                if (String.IsNullOrEmpty(name))
                {
                    return BadRequest();
                }
                var courses = _dbContext.Courses.Where(n => n.Name == name).FirstOrDefault();
                var CourseDTO = new CourseDTO()
                {
                    //courseID = courses.courseID,
                    Id = courses.Id,
                    Name = courses.Name,
                    Description = courses.Description
                };
                //var CourseDTO =  courseRepository.courses.Where(n => n.name == name).Select(s => new CourseDTO()
                //{
                ////    courseID = s.courseID,
                //    name = s.name,
                //    age = s.age,
                //    email = s.email
                //}).FirstOrDefault();
                if (CourseDTO == null)
                {
                    return NotFound($"{name} not found");

                }
                return Ok(CourseDTO);
            }

            [HttpDelete]
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]
            [ProducesResponseType(404)]
            public ActionResult<bool> deletecourse(int id)
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var deleting = _dbContext.Courses.Where(n => n.Id == id).FirstOrDefault();
                if (deleting == null)
                {
                    return NotFound();
                }
                _dbContext.Courses.Remove(deleting);
                _dbContext.SaveChanges();
                return Ok(true);
            }

            [HttpPost("Create")]
            [ProducesResponseType(200)]
            //[ProducesResponseType(400)]
            [ProducesResponseType(404)]
            public ActionResult<CourseDTO> CreateCourse([FromBody] CourseDTO model)
            {
                if (model == null)
                {
                    return BadRequest();
                }
                //int newid = _dbContext.Courses.LastOrDefault().courseID + 1;

                Course coursenew = new Course
                {
                    //courseID = newid,
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description
                };
                _dbContext.Courses.Add(coursenew);
                _dbContext.SaveChanges();
                return Ok(coursenew);
            }

            [HttpPut]
            [Route("Update")]
            [ProducesResponseType(202)]
            [ProducesResponseType(400)]
            [ProducesResponseType(404)]
            public ActionResult UpdateCourse([FromBody] CourseDTO model)
            {
                if (model == null || model.Id == 0)
                {
                    return BadRequest();
                }
                var existingCourse = _dbContext.Courses.Where(s => s.Id == model.Id).FirstOrDefault();
                if (existingCourse == null)
                {
                    return NotFound("Course id not found");
                }
                existingCourse.Id = model.Id;
                existingCourse.Name = model.Name;
                existingCourse.Description = model.Description;

                _dbContext.SaveChanges();

                return NoContent();
            }
            [HttpPatch]
            [Route("{id:int}UpdatePartial")]
            [ProducesResponseType(202)]
            [ProducesResponseType(400)]
            [ProducesResponseType(404)]
            [ProducesResponseType(500)]
            public ActionResult UpdateCoursePartial(int id, [FromBody] JsonPatchDocument<CourseDTO> patchDocument)
            {
                if (patchDocument == null || id <= 0)
                {
                    return BadRequest();
                }
                var existingCourse = _dbContext.Courses.Where(s => s.Id == id).FirstOrDefault();
                if (existingCourse == null)
                {
                    return NotFound("Course id not found");
                }
            var courseDto = new CourseDTO()
            {
                Id = existingCourse.Id,
                Name = existingCourse.Name,
                Description = existingCourse.Description
            };
                patchDocument.ApplyTo(courseDto, ModelState);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                existingCourse.Id = courseDto.Id;
                existingCourse.Name = courseDto.Name;
                existingCourse.Description = courseDto.Description;

                _dbContext.SaveChanges();
                return NoContent();
            }

        }
    }

