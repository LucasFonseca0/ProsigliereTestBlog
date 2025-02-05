using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPostService(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }

        public async Task<IEnumerable<BlogPostDTO>> GetAllPostsAsync()
        {
            var blogPosts = await _blogPostRepository.GetAllPostsAsync();
         
            return blogPosts.Select(b => new BlogPostDTO
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                CommentCounter = b.CommentCounter
            }).ToList();
        }

        public async Task<BlogPost> GetPostByIdAsync(Guid id)
        {
            var blogPost = await _blogPostRepository.GetPostByIdAsync(id);
            if (blogPost == null)
            {
                return null;
            }

            return blogPost;
        }

        public async Task AddPostAsync(BlogPost blogPost)
        {
                   await _blogPostRepository.AddPostAsync(blogPost);
        }
    }
}
