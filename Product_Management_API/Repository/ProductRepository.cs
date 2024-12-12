using Microsoft.EntityFrameworkCore;
using Product_Management_API.Models;

namespace Product_Management_API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context; // Dependency injection
        }

        public Product AddProduct(Product p)
        {
            _context.Products.Add(p);
            _context.SaveChanges();
            return p; // Return the added product
        }

        public List<Product> GetAllProducts(int Page_Number, int Page_Size)
        {
            return _context.Products
                .OrderByDescending(p => p.DateAdded) // Sort products by the most recent first.

                .Skip((Page_Number - 1) * Page_Size) // Skip records for previous pages.

                .Take(Page_Size) // Limit the number of records to Page_Size.
                .ToList(); // Execute the query and return the result as a list.
        }

        public Product UpdateProduct(Product p)
        {
            _context.Products.Update(p);
            _context.SaveChanges();
            return p; // Return the updated product
        }

        public Product GetProductById(int ID)
        {
            return _context.Products.Find(ID);
        }

        public bool DeleteProduct(int ID)
        {
            var product = _context.Products.Find(ID);
            if (product == null) return false;

            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }


    }
}
