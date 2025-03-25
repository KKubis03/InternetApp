namespace OzeSome.Data.Models.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Guid AddressId { get; set; }
        // Address data
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Code { get; set; } 
        public string? City { get; set; }
        public string? Country { get; set; } 
    }
}
