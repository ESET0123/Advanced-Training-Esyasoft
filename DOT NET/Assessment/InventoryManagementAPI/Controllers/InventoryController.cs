using InventoryManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using InventoryManagementAPI.Models;

namespace InventoryManagementAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IGenericRepository<Category > _categoryRepository;
        private readonly IGenericRepository<Product> _productRepository;



        public InventoryController(IGenericRepository<Category> categoryRepository,IGenericRepository<Product> productRepository)
            {
                _categoryRepository = categoryRepository;
                _productRepository = productRepository;
            }

        [HttpGet("category/all")]
        public async Task<ActionResult<List<Category>>> GetAllCategory()
        {
            var students = await _categoryRepository.GetAll();
            return Ok(students);
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var student = await _categoryRepository.GetById(id);

            if (student == null)
            {
                return NotFound($"Category with ID {id} not found");
            }

            return Ok(student);
        }



        [HttpPost("category/create")]
        public async Task<ActionResult> CreateCategory([FromBody] Category student)
        {
            if (student == null)
            {
                return BadRequest("Category cannot be null");
            }

            _categoryRepository.Add(student);
            return Ok(new { message = "Category created successfully"});
        }

        [HttpPut("category/update")]
        public async Task<ActionResult> UpdateCategory([FromBody] Category student)
        {
            if (student == null)
            {
                return BadRequest("Category cannot be null");
            }

            await _categoryRepository.Update(student);
            return Ok(new { message = "Category updated successfully"});
        }

        [HttpDelete("category/delete/{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

                await _categoryRepository.Delete(id);

            return Ok(new { message = "Category deleted successfully", success = true });
        }

        //// Product Endpoints
        [HttpGet("product/all")]
        public async Task<ActionResult<List<Category>>> GetAllProducts()
        {
            var students = await _categoryRepository.GetAll();
            return Ok(students);
        }

        [HttpGet("product/{id}")]
        public async Task<ActionResult<Category>> GetProductById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            var student = await _categoryRepository.GetById(id);

            if (student == null)
            {
                return NotFound($"Category with ID {id} not found");
            }

            return Ok(student);
        }



        [HttpPost("product/create")]
        public async Task<ActionResult> CreateProduct([FromBody] Category student)
        {
            if (student == null)
            {
                return BadRequest("Category cannot be null");
            }

            await _categoryRepository.Add(student);
            return Ok(new { message = "Category created successfully" });
        }

        [HttpPut("product/update")]
        public async Task<ActionResult> UpdateProduct([FromBody] Category student)
        {
            if (student == null)
            {
                return BadRequest("Category cannot be null");
            }

            await _categoryRepository.Update(student);
            return Ok(new { message = "Category updated successfully" });
        }

        [HttpDelete("product/delete/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID must be greater than 0");
            }

            await _categoryRepository.Delete(id);

            return Ok(new { message = "Category deleted successfully", success = true });
        }
    }
}
