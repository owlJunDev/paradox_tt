namespace Backend.DTO
{
    public class NoteDto
    {
        public string? title { get; set; }
        
        public string? content { get; set; }

        public List<long>? tagId { get; set; }
    }
}