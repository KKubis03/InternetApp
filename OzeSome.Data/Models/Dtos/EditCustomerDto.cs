namespace OzeSome.Data.Models.Dtos
{
    public class EditCustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Guid AddressId { get; set; }
    }
}
