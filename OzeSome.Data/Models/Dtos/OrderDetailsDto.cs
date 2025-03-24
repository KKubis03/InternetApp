namespace OzeSome.Data.Models.Dtos
{
    public class OrderDetailsDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        // Order Data
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = null!;
        // Customer Data
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        // Product Data
        public string ProductName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public decimal ProductPrice { get; set; }
    }
}
