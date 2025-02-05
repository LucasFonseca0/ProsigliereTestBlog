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
            try
            {
                var blogPosts = await _blogPostRepository.GetAllPostsAsync();
                return blogPosts.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<BlogPost> GetPostByIdAsync(Guid id)
        {
            try
            {
                var blogPost = await _blogPostRepository.GetPostByIdAsync(id);
                return blogPost;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddPostAsync(BlogPost blogPost)
        {
            try
            {
                await _blogPostRepository.AddPostAsync(blogPost);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
