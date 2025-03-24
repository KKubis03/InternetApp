namespace OzeSome.Data.Models.Dtos
{
    public class NewMeetingDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime MeetingDate { get; set; }
        public string MeetingStatus { get; set; } = null!;
    }
}
