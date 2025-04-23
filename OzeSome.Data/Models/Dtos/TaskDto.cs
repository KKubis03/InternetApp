namespace OzeSome.Data.Models.Dtos
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public int TaskStatusId { get; set; }
        public string? TaskStatusName { get; set; }
        public string Content { get; set; } = null!;
        public DateTime Deadline { get; set; }
    }
}
