namespace OzeSome.Data.Models.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
