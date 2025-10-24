using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductCatalogAPI.Model;
using System;
using System.Reflection;

//Assignment: Product Catalog API
//Objective: Manage products in an online catalog.
//Entity: ProductDTO → ProductID, Name, Category, Price, StockQuantity
//Tasks:
//1.GET all products -------
//2.GET product by ID -------
//3.POST → Add new product ----------
//Ensure Price > 0 and StockQuantity >= 0
//4.PUT → Replace product details completely
//5.PATCH → Update price or stock quantity only
//Implement validation using [Required], [Range], [StringLength]

namespace ProductCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApp : ControllerBase
    {

        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<ProductDTO>> getProducts()
        {
            var products = ProductRepository.Products.Select(s => new ProductDTO()
            {
                //ProductID = s.ProductID,
                Name = s.Name,
                Category = s.Category,
                Price = s.Price,
                StockQuantity = s.StockQuantity
            });
            return Ok(products);
        }


        [HttpGet]
        //[Route("{id:int}")]  //[Route("{id:int}", Name = "getproductbyid")]
        [HttpGet("{id:int}", Name = "getproductbyid")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<ProductDTO> getproductbyid(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var products = ProductRepository.Products.Where(s => s.ProductID == id).FirstOrDefault();
            var productDTO = new ProductDTO()
            {
                //ProductID = products.ProductID,
                Name = products.Name,
                Category = products.Category,
                Price = products.Price,
                StockQuantity = products.StockQuantity
            };
            if (productDTO == null)
            {
                return NotFound($"Id {id} not found");
            }
            return Ok(productDTO);
        }

        [HttpPost("Create")]
        [ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<ProductDTO> CreateProduct([FromBody] ProductDTO model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            int newid = ProductRepository.Products.LastOrDefault().ProductID + 1;

            Products productnew = new Products
            {
                ProductID = newid,
                Name = model.Name,
                Category = model.Category,
                Price = model.Price,
                StockQuantity = model.StockQuantity
            };
            ProductRepository.Products.Add(productnew);
            return Ok(productnew);
        }

        [HttpPut]
        [Route("Update")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult UpdateProduct([FromBody] Products model)
        {
            if (model == null || model.ProductID == 0)
            {
                return BadRequest();
            }
            var existingProduct = ProductRepository.Products.Where(s => s.ProductID == model.ProductID).FirstOrDefault();
            if (existingProduct == null)
            {
                return NotFound("Product id not found");
            }
            existingProduct.ProductID = model.ProductID;
            existingProduct.Name = model.Name;
            existingProduct.Category = model.Category;
            existingProduct.Price = model.Price;
            existingProduct.StockQuantity = model.StockQuantity;

            return NoContent();
        }
        [HttpPatch]
        [Route("{id:int}UpdatePartial")]
        [ProducesResponseType(202)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult UpdateProductPartial(int id, [FromBody] JsonPatchDocument<ProductDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
            {
                return BadRequest();
            }
            var existingProduct = ProductRepository.Products.Where(s => s.ProductID == id).FirstOrDefault();
            if (existingProduct == null)
            {
                return NotFound("Product id not found");
            }
            var productDto = new ProductDTO()
            {
                //ProductID = existingProduct.ProductID,
                Name = existingProduct.Name,
                Category = existingProduct.Category,
                Price = existingProduct.Price,
                StockQuantity = existingProduct.StockQuantity
            };
            patchDocument.ApplyTo(productDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            //existingProduct.ProductID = productDto.ProductID;
            existingProduct.Name = productDto.Name;
            existingProduct.Category = productDto.Category;
            existingProduct.Price = productDto.Price;
            existingProduct.StockQuantity = productDto.StockQuantity;

            return NoContent();
        }

    }
}