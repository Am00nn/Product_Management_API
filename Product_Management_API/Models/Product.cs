namespace Product_Management_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
