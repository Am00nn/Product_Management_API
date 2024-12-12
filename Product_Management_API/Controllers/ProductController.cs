using Microsoft.AspNetCore.Mvc;
using Product_Management_API.Models;
using Product_Management_API.Service;

namespace Product_Management_API.Controllers
{
    // Controllers/ProductController.cs
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        // Constructor to inject the product service
        public ProductController(IProductService service)
        {
            _service = service;
        }

        // Endpoint to add a new product
        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductInputDTO dto)
        {
            // Validate input model
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Call service to add the product and return the result
            var output = _service.AddProduct(dto);
            return CreatedAtAction(nameof(GetProductById), new { id = output.Name }, output);
        }

        // Endpoint to retrieve all products with pagination
        [HttpGet]
        public IActionResult GetAllProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            // Call service to get products and return them
            var products = _service.GetAllProducts(pageNumber, pageSize);
            return Ok(products);
        }

        // Endpoint to retrieve a product by ID
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            // Call service to get the product
            var product = _service.GetProductById(id);

            // Return 404 if product not found, otherwise return the product
            if (product == null) return NotFound();
            return Ok(product);
        }

        // Endpoint to update an existing product
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductInputDTO dto)
        {
            // Validate input model
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Call service to update the product
            var updatedProduct = _service.UpdateProduct(id, dto);

            // Return 404 if product not found, otherwise return updated product
            if (updatedProduct == null) return NotFound();
            return Ok(updatedProduct);
        }

        // Endpoint to delete a product by ID
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            // Call service to delete the product
            var success = _service.DeleteProduct(id);

            // Return 404 if product not found, otherwise return no content
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
