using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs;

namespace Infrastructure.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly AppDbContext _context;

        public BlogPostRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BlogPostDTO>> GetAllPostsAsync()
        {
            var posts = await _context.BlogPosts
                .Include(b => b.Comments)
                .Select(b => new BlogPostDTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Content = b.Content,
                    CommentCounter = b.Comments.Count
                })
                .ToListAsync();

            return posts;
        }

        public async Task<BlogPost> GetPostByIdAsync(Guid id)
        {
            var blogPost = await _context.BlogPosts
                .Include(b => b.Comments)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blogPost == null)
            {
                throw new KeyNotFoundException($"BlogPost with Id {id} not found.");
            }

            await _context.Entry(blogPost)
                .Collection(b => b.Comments)
                .LoadAsync();

            return blogPost;
        }

        public async Task AddPostAsync(BlogPost blogPost)
        {
            await _context.BlogPosts.AddAsync(blogPost);
            await _context.SaveChangesAsync();
        }
    }
}