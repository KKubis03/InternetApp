namespace OzeSome.Data.Models.Dtos.New
{
    public class NewProductDto
    {
        public Guid CategoryId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}
