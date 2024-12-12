using Product_Management_API.Models;

namespace Product_Management_API.Repository
{
    public interface IProductRepository
    {
        Product AddProduct(Product p);
        bool DeleteProduct(int ID);
        List<Product> GetAllProducts(int Page_Number, int Page_Size);
        Product GetProductById(int ID);
        Product UpdateProduct(Product p);
    }
}