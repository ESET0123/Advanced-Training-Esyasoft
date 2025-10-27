using EmployeeManagementAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _IEmployeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _IEmployeeRepository = employeeRepository;
        }
        [HttpGet]
        [Route("All")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<Employee>>> getEmployees()
        {
            var students = await _IEmployeeRepository.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Employee>> getstudentbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var student = await _IEmployeeRepository.GetByIdAsync(id);
            if (student == null)
            {
                return NotFound($"Id {id} not found");
            }
            return Ok(student);
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> CreateEmployees([FromBody] Employee model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            Employee employeenew = new Employee
            {
                FullName = model.FullName,
                Department = model.Department,
                Salary = model.Salary,
                Email = model.Email
            };
            await _IEmployeeRepository.AddAsync(employeenew);
            return Ok();

        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateEmployee([FromBody] Employee model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var existingstudent = await _IEmployeeRepository.GetByIdAsync(model.EmployeeId);
            if (existingstudent == null)
            {
                return NotFound();
            }

            Employee employeenew = new Employee
            {
                EmployeeId = model.EmployeeId,
                FullName = model.FullName,
                Department = model.Department,
                Salary = model.Salary,
                Email = model.Email
            };

            await _IEmployeeRepository.UpdateAsync(employeenew);
            //if (result == 1)
                return Ok();
            //else
            //    return NotFound();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> deletestudent(int id)
        {
             await _IEmployeeRepository.DeleteAsync(id);
            return Ok();
        }
    }
}
