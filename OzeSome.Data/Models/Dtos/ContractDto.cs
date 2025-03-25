namespace OzeSome.Data.Models.Dtos
{
    public class ContractDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        // Customer Data
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        // Order Data
        public DateTime? OrderDate { get; set; }
        public string? OrderStatus { get; set; }
        public string? ContractStatus { get; set; }
    }
}
