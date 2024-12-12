using Microsoft.EntityFrameworkCore;
using Product_Management_API.Models;

namespace Product_Management_API.Repository
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context; // Dependency injection 
        }

        public async Task<Product> AddProduct(Product p)
        {
            // Ensure that the product is not null 
            _context.Products.Add(p);

            await _context.SaveChangesAsync(); 

            return p; // Return the added product
        }

        public async Task<List<Product>> GetAllProducts(int Page_Number, int Page_Size)
        {
            // Validate Page_Number and Page_Size to ensure they are greater than 0.

            return await _context.Products
                .OrderByDescending(p => p.DateAdded) // Sort products by the most recent first.

                .Skip((Page_Number - 1) * Page_Size) // Skip records for previous pages.

                .Take(Page_Size) // Limit the number of records to Page_Size.

                .ToListAsync(); // Execute the query and return the result as a list.
        }

        public async Task<Product> UpdateProduct(Product p)
        {
            // Check if the product exists before updating 
            _context.Products.Update(p);

            await _context.SaveChangesAsync(); 

            return p; // Return the updated product 
        }

        public async Task<Product> GetProductById(int ID)
        {
            // Fetch the product by its ID. Returns null if the product does not exist.

            return await _context.Products.FindAsync(ID);
        }

        public async Task<bool> DeleteProduct(int ID)
        {
            var product = await _context.Products.FindAsync(ID); // Find the product by its ID.

            if (product == null) return false; // Return false if the product does not exist.

            _context.Products.Remove(product); // Remove the product from the database.

            await _context.SaveChangesAsync(); // Persist changes asynchronously.

            return true; // Return true to  successful deletion.
        }


    }
}
