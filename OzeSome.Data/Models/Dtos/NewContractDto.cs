namespace OzeSome.Data.Models.Dtos
{
    public class NewContractDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }
        public string ContractStatus { get; set; } = null!;
    }
}
