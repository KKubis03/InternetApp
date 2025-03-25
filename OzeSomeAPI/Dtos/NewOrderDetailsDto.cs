namespace OzeSome.Data.Models.Dtos
{
    public class NewOrderDetailsDto
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
