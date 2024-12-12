using Product_Management_API.Models;

namespace Product_Management_API.Service
{
    public interface IProductService
    {
        ProductOutputDTO AddProduct(ProductInputDTO input);
        bool DeleteProduct(int id);
        List<ProductOutputDTO> GetAllProducts(int pageNumber, int pageSize);
        ProductOutputDTO GetProductById(int id);
        ProductOutputDTO UpdateProduct(int id, ProductInputDTO input);
    }
}