namespace OzeSome.Data.Models.Dtos
{
    public class NewMeetingDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime MeetingDate { get; set; }
        public string MeetingStatus { get; set; } = null!;
    }
}
