using Application.Interfaces;
using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

public class BlogPostServiceTests
{
    private readonly Mock<IBlogPostRepository> _mockBlogPostRepository;
    private readonly IBlogPostService _blogPostService;

    public BlogPostServiceTests()
    {
        _mockBlogPostRepository = new Mock<IBlogPostRepository>();
        _blogPostService = new BlogPostService(_mockBlogPostRepository.Object);
    }

    [Fact]
    public async Task GetAllPostsAsync_ShouldReturnAllPosts()
    {
        var blogPosts = new List<BlogPostDTO>
        {
            new BlogPostDTO { Id = Guid.NewGuid(), Title = "Post 1", Content = "Content 1", CommentCounter = 0 },
            new BlogPostDTO { Id = Guid.NewGuid(), Title = "Post 2", Content = "Content 2", CommentCounter = 0 }
        };
        _mockBlogPostRepository.Setup(repo => repo.GetAllPostsAsync()).ReturnsAsync(blogPosts);

        var result = await _blogPostService.GetAllPostsAsync();

        Assert.Equal(blogPosts.Count, result.Count());
    }

    [Fact]
    public async Task GetPostByIdAsync_ShouldReturnPost()
    {
        var postId = Guid.NewGuid();
        var blogPost = new BlogPost { Id = postId, Title = "Post", Content = "Content" };
        _mockBlogPostRepository.Setup(repo => repo.GetPostByIdAsync(postId)).ReturnsAsync(blogPost);

        var result = await _blogPostService.GetPostByIdAsync(postId);

        Assert.Equal(blogPost, result);
    }

    [Fact]
    public async Task AddPostAsync_ShouldAddPost()
    {
        var blogPost = new BlogPost { Id = Guid.NewGuid(), Title = "New Post", Content = "New Content" };

        await _blogPostService.AddPostAsync(blogPost);

        _mockBlogPostRepository.Verify(repo => repo.AddPostAsync(It.Is<BlogPost>(b => b.Id == blogPost.Id && b.Title == blogPost.Title && b.Content == blogPost.Content)), Times.Once);
    }
}