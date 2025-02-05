using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId) =>
            _commentRepository.GetCommentsByPostIdAsync(postId); 
        public async Task AddCommentAsync(Guid postId, CommentDTO commentDTO)
        {
            var comment = new Comment
            {
                Id = commentDTO.Id,
                Content = commentDTO.Content,
                BlogPostId = postId
            };

            await _commentRepository.AddCommentAsync(postId, comment);
        }
    }
}
