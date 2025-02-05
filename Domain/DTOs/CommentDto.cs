namespace Domain.DTOs
{
    public class CommentDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
