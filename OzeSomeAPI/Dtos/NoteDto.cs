namespace OzeSome.Data.Models.Dtos
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
