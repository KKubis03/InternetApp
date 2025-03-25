namespace OzeSome.Data.Models.Dtos
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string Street { get; set; } = null!;
        public string Number { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
    }
}
