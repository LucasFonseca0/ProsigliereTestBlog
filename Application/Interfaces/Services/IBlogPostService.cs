using Domain.DTOs;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IBlogPostService
    {
        Task<IEnumerable<BlogPostDTO>> GetAllPostsAsync();
        Task<BlogPost> GetPostByIdAsync(Guid id);
        Task AddPostAsync(BlogPost blogPost);
    }
}
