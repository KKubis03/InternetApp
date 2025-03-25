namespace OzeSome.Data.Models.Dtos
{
    public class OrderDetailsDto
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        // Order Data
        public DateTime? OrderDate { get; set; }
        public string? OrderStatus { get; set; }
        // Customer Data
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        // Product Data
        public string? ProductName { get; set; } 
        public string? CategoryName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
