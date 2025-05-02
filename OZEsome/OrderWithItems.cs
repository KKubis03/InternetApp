using OZEsome;

namespace OzeSome
{
    public class OrderWithItems
    {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderStatusId { get; set; }
        public string? OrderStatusName { get; set; }
        // Customer Data
        public Guid CustomerId { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public ICollection<OrderItemDto>? OrderItems { get; set; }
        public decimal Total { get; set; } = 0;
    }
}
