using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class BlogPost
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
