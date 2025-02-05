using Domain.DTOs;
using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPostDTO>> GetAllPostsAsync();
        Task<BlogPost> GetPostByIdAsync(Guid id);
        Task AddPostAsync(BlogPost blogPost);
    }
}
