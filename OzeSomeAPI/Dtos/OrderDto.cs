namespace OzeSome.Data.Models.Dtos
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = null!;
    }
}
