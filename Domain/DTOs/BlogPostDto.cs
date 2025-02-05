using System.Text.Json.Serialization;

namespace Domain.DTOs
{
    public class BlogPostDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int CommentCounter { get; set; }
    }
}
