using System.Text.Json.Serialization;

namespace OzeSome.Data.Models.Dtos
{
    public class MeetingDto
    {
        public Guid Id { get; set; }
        // Customer Data
        public Guid CustomerId { get; set; }
        public string? CustomerFirstName { get; set; }
        public string? CustomerLastName { get; set; }
        public DateTime MeetingDate { get; set; }
        public string MeetingStatus { get; set; } = null!;
    }
}
