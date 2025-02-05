using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId);
        Task AddCommentAsync(Guid postId, Comment comment);
    }
}
