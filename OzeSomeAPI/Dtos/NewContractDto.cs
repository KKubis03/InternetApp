namespace OzeSome.Data.Models.Dtos
{
    public class NewContractDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public string ContractStatus { get; set; } = null!;
    }
}
