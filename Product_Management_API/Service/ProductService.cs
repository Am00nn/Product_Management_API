using Product_Management_API.Models;
using Product_Management_API.Repository;

namespace Product_Management_API.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        // Add a new product
        public ProductOutputDTO AddProduct(ProductInputDTO input)
        {
            // Create a new product from input
            var product = new Product
            {
                Name = input.Name,

                Price = input.Price,

                Category = input.Category
            };

            // Save the product and return the result
            var createdProduct = _repository.AddProduct(product);

            return new ProductOutputDTO
            {
                Name = createdProduct.Name,

                Price = createdProduct.Price,

                Category = createdProduct.Category,

                DateAdded = createdProduct.DateAdded
            };
        }

        // Get all products with pagination
        public List<ProductOutputDTO> GetAllProducts(int pageNumber, int pageSize)
        {
            // Retrieve products from repository
            var products = _repository.GetAllProducts(pageNumber, pageSize);

            // Convert to output DTOs
            return products.Select(p => new ProductOutputDTO
            {
                Name = p.Name,
                Price = p.Price,
                Category = p.Category,
                DateAdded = p.DateAdded
            }).ToList();
        }

        // Get a product by its ID
        public ProductOutputDTO GetProductById(int id)
        {
            // Find product by ID
            var product = _repository.GetProductById(id);

            if (product == null) return null;

            // Convert to output DTO
            return new ProductOutputDTO
            {
                Name = product.Name,

                Price = product.Price,

                Category = product.Category,

                DateAdded = product.DateAdded
            };
        }

        // Update an existing product
        public ProductOutputDTO UpdateProduct(int id, ProductInputDTO input)
        {
            // Find product by ID

            var product = _repository.GetProductById(id);

            if (product == null) return null;

            // Update product details

            product.Name = input.Name;

            product.Price = input.Price;

            product.Category = input.Category;

            // Save updated product
            var updatedProduct = _repository.UpdateProduct(product);

            return new ProductOutputDTO
            {
                Name = updatedProduct.Name,

                Price = updatedProduct.Price,

                Category = updatedProduct.Category,

                DateAdded = updatedProduct.DateAdded
            };
        }

        // Delete a product by its ID
        public bool DeleteProduct(int id)
        {
            // Delete product and return the result

            return _repository.DeleteProduct(id);
        }




    }
}
