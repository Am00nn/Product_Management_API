using System.ComponentModel.DataAnnotations;

namespace Product_Management_API.Models
{
    public class ProductInputDTO
    {
        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required and must gerater than 0 .")]
        public decimal Price { get; set; }

        public string Category { get; set; } = "general";
    }
}
