namespace OzeSome.Data.Models.Dtos.New
{
    public class NewTaskDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime Deadline { get; set; }
        public int TaskStatusId { get; set; }
    }
}
