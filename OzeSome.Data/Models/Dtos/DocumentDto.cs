namespace OzeSome.Data.Models.Dtos
{
    public class DocumentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
    }
}
