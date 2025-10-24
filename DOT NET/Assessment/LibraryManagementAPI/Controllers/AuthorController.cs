using LibraryManagementAPI.Data.Repository;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _myRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _myRepository = authorRepository;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Author>>> getAuthors()
        {
            var author = await _myRepository.GetAllAsync();
            return Ok(author);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Author>> getauthorbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var author = await _myRepository.GetbyidAsync(id);
            if (author == null)
            {
                return NotFound($"Id {id} not found");
            }
            return Ok(author);
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> CreateAuthor([FromBody] AuthorDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            Author authornew = new Author
            {
                Name = model.Name,
                Country = model.Country,
            };
            var studentId = await _myRepository.CreateAsync(authornew);
            return Ok(studentId);

        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<bool>> UpdateAuthor([FromBody] Author model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var existingauthor = await _myRepository.GetbyidAsync(model.AuthorId);
            if (existingauthor == null)
            {
                return NotFound();
            }

            Author authornew = new Author
            {
                AuthorId = model.AuthorId,
                Name = model.Name,
                Country = model.Country,
            };

            var result = await _myRepository.UpdateAsync(existingauthor, authornew);
            if (result == 1)
                return Ok(true);
            else
                return NotFound();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<bool>> deleteAuthor(int id)
        {
            return await _myRepository.DeleteAsync(id);
        }
    }
}
