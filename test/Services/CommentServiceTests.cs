using Application.Interfaces;
using Application.Services;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class CommentServiceTests
{
    private readonly Mock<ICommentRepository> _mockCommentRepository;
    private readonly ICommentService _commentService;

    public CommentServiceTests()
    {
        _mockCommentRepository = new Mock<ICommentRepository>();
        _commentService = new CommentService(_mockCommentRepository.Object);
    }

    [Fact]
    public async Task GetCommentsByPostIdAsync_ShouldReturnComments()
    {
        var postId = Guid.NewGuid();
        var comments = new List<Comment> { new Comment { Id = Guid.NewGuid(), Content = "Test Comment", BlogPostId = postId } };
        _mockCommentRepository.Setup(repo => repo.GetCommentsByPostIdAsync(postId)).ReturnsAsync(comments);

        var result = await _commentService.GetCommentsByPostIdAsync(postId);

        Assert.Equal(comments, result);
    }

    [Fact]
    public async Task AddCommentAsync_ShouldAddComment()
    {
        var postId = Guid.NewGuid();
        var commentDTO = new CommentDTO { Id = Guid.NewGuid(), Content = "New Comment" };
        var comment = new Comment { Id = commentDTO.Id, Content = commentDTO.Content, BlogPostId = postId };

        await _commentService.AddCommentAsync(postId, commentDTO);

        _mockCommentRepository.Verify(repo => repo.AddCommentAsync(postId, It.Is<Comment>(c => c.Id == comment.Id && c.Content == comment.Content && c.BlogPostId == postId)), Times.Once);
    }
}