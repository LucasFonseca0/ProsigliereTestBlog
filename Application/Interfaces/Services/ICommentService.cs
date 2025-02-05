using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId);
        Task AddCommentAsync(Guid postId, CommentDTO commentDTO);
    }
}
