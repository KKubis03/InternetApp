namespace OzeSome.Data.Models.Dtos
{
    public class NewOrderDetailsDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
