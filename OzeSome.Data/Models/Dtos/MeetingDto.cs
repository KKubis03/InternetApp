namespace OzeSome.Data.Models.Dtos
{
    public class MeetingDto
    {
        public Guid Id { get; set; }
        // Customer Data
        public string CustomerFirstName { get; set; } = null!;
        public string CustomerLastName { get; set; } = null!;
        public DateTime MeetingDate { get; set; }
        public string MeetingStatus { get; set; } = null!;
    }
}
