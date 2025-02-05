using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CommentRepository(AppDbContext context) : ICommentRepository
    {
        private readonly AppDbContext _context = context;

        public async Task AddCommentAsync(Guid postId, Comment comment)
        {
            try
            {
                comment.BlogPostId = postId;
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while adding the comment.", ex);
            }
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(Guid postId)
        {
            try
            {
                return await _context.Comments
                    .Where(c => c.BlogPostId == postId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving comments by post ID.", ex);
            }
        }
    }
}
