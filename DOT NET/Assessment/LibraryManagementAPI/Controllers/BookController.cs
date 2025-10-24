using LibraryManagementAPI.Data.Repository;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookRepository _myRepository;

        public BookController(IBookRepository bookRepository)
        {
            _myRepository = bookRepository;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<Book>>> getBooks()
        {
            var book = await _myRepository.GetAllAsync();
            return Ok(book);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Book>> getbookbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var book = await _myRepository.GetbyidAsync(id);
            if (book == null)
            {
                return NotFound($"Id {id} not found");
            }
            return Ok(book);
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<int>> createBook([FromBody] BookDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            Book booknew = new Book
            {
                Title = model.Title,
                Genre = model.Genre,

            };
            var BookId = await _myRepository.CreateAsync(booknew);
            return Ok(BookId);

        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<bool>> UpdateBook([FromBody] Book model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var existingbook = await _myRepository.GetbyidAsync(model.BookId);
            if (existingbook == null)
            {
                return NotFound();
            }

            Book booknew = new Book
            {
                Title = model.Title,
                Genre = model.Genre,
            };

            var result = await _myRepository.UpdateAsync(existingbook, booknew);
            if (result == 1)
                return Ok(true);
            else
                return NotFound();
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<bool>> deleteBook(int id)
        {
            return await _myRepository.DeleteAsync(id);
        }
    }
}
