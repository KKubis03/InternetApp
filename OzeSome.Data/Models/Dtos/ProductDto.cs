namespace OzeSome.Data.Models.Dtos
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
