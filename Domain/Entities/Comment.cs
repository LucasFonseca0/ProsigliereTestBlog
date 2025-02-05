using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Content { get; set; }
        public Guid BlogPostId { get; set; }

        [JsonIgnore]
        public BlogPost BlogPost { get; set; }
    }
}
