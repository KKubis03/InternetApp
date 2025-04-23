namespace OzeSome.Data.Models.Dtos.New
{
    public class NewOrderItemDto
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
