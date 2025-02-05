using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostController(IBlogPostService blogPostService, ICommentService commentService, ILogger<BlogPostController> logger) : ControllerBase
    {
        private readonly IBlogPostService _blogPostService = blogPostService;
        private readonly ICommentService _commentService = commentService;
        private readonly ILogger<BlogPostController> _logger = logger;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPostDTO>>> GetAllPosts()
        {
            try
            {
                var posts = await _blogPostService.GetAllPostsAsync();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when fetching all blog posts {ex.Message}");
                return BadRequest($"Error when fetching all blog posts {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetPostById(Guid id)
        {
            try
            {
                var post = await _blogPostService.GetPostByIdAsync(id);
                if (post == null)
                {
                    return NotFound("No posts found for this Id");
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when fetching post by Id {ex.Message}");
                return BadRequest($"Error when fetching post by Id {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost([FromBody] BlogPost blogPost)
        {
            try
            {
                await _blogPostService.AddPostAsync(blogPost);
                return CreatedAtAction(nameof(GetPostById), new { id = blogPost.Id }, blogPost);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when creating a new post {ex.Message}");
                return BadRequest($"Error when creating a new post {ex.Message}");
            }
        }

        [HttpPost("{postId}/comments")]
        public async Task<ActionResult<CommentDTO>> AddComment(Guid postId, [FromBody] CommentDTO comment)
        {
            try
            {
                var post = await _blogPostService.GetPostByIdAsync(postId);
                if (post == null)
                {
                    return NotFound("No posts found with this id");
                }

                
                await _commentService.AddCommentAsync(postId, comment);
                return Ok(comment);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when creating a new comment {ex.Message}");
                return BadRequest($"Error when creating a new comment {ex.Message}");
            }
        }
    }
}
