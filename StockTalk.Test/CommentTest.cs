using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StockTalk.Entities.DTOs.CommentDto;
using StockTalk.Entities.Models;
using StockTalk.Infrastructure.Repositories.Interfaces;
using StockTalk.Service.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StockTalk.Service.Tests
{
    public class CommentTest
    {
        private readonly Mock<ICommentRepository> _commentRepositoryMock;
        private readonly Mock<IStockRepository> _stockRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly CommentService _commentService;

        public CommentTest()
        {
            _commentRepositoryMock = new Mock<ICommentRepository>();
            _stockRepositoryMock = new Mock<IStockRepository>();
            _mapperMock = new Mock<IMapper>();
            _commentService = new CommentService(_commentRepositoryMock.Object, _stockRepositoryMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task StockExist_StockExists_ReturnsTrue()
        {
            // Arrange
            var stockId = 1;
            _stockRepositoryMock.Setup(repo => repo.GetByIdAsync(stockId))
                                .ReturnsAsync(new Stock());

            // Act
            var result = await _commentService.StockExist(stockId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task StockExist_StockDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var stockId = 1;
            _stockRepositoryMock.Setup(repo => repo.GetByIdAsync(stockId))
                                .ReturnsAsync((Stock)null);

            // Act
            var result = await _commentService.StockExist(stockId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task GetStockCommentsAsync_StockNotFound_ReturnsNotFound()
        {
            // Arrange
            var stockId = 1;
            _stockRepositoryMock.Setup(repo => repo.GetByIdAsync(stockId))
                                .ReturnsAsync((Stock)null);

            // Act
            var result = await _commentService.GetStockCommentsAsync(stockId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Stock not found.", notFoundResult.Value.GetType().GetProperty("message").GetValue(notFoundResult.Value).ToString());
        }

        [Fact]
        public async Task GetStockCommentsAsync_StockFound_ReturnsOkWithComments()
        {
            // Arrange
            var stockId = 1;
            var comments = new List<Comment> { new Comment { Id = 1, Content = "Test comment" } };
            var commentDtos = new List<ToCommentDto> { new ToCommentDto { Content = "Test comment" } };

            _stockRepositoryMock.Setup(repo => repo.GetByIdAsync(stockId))
                                .ReturnsAsync(new Stock());
            _commentRepositoryMock.Setup(repo => repo.GetAsync(stockId))
                                  .ReturnsAsync(comments);
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<ToCommentDto>>(comments))
                       .Returns(commentDtos);

            // Act
            var result = await _commentService.GetStockCommentsAsync(stockId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(commentDtos, okResult.Value);
        }

        [Fact]
        public async Task CreateAsync_StockNotFound_ReturnsNotFound()
        {
            // Arrange
            var createCommentDto = new CreateCommentDto { StockId = 1 };
            _stockRepositoryMock.Setup(repo => repo.GetByIdAsync(createCommentDto.StockId))
                                .ReturnsAsync((Stock)null);

            // Act
            var result = await _commentService.CreateAsync(createCommentDto);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Stock not found.", notFoundResult.Value.GetType().GetProperty("message").GetValue(notFoundResult.Value).ToString());
        }

        [Fact]
        public async Task CreateAsync_ValidComment_ReturnsOkWithCreatedComment()
        {
            // Arrange
            var createCommentDto = new CreateCommentDto { StockId = 1, Content = "Test comment" };
            var stock = new Stock { Id = 1 };
            var comment = new Comment { Id = 1, Content = "Test comment" };
            var toCommentDto = new ToCommentDto { Content = "Test comment" };

            _stockRepositoryMock.Setup(repo => repo.GetByIdAsync(createCommentDto.StockId))
                                .ReturnsAsync(stock);
            _mapperMock.Setup(mapper => mapper.Map<Comment>(createCommentDto))
                       .Returns(comment);
            _mapperMock.Setup(mapper => mapper.Map<ToCommentDto>(comment))
                       .Returns(toCommentDto);

            // Act
            var result = await _commentService.CreateAsync(createCommentDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(toCommentDto, okResult.Value);
        }

        [Fact]
        public async Task GetByIdAsync_CommentNotFound_ReturnsNotFound()
        {
            // Arrange
            var commentId = 1;
            _commentRepositoryMock.Setup(repo => repo.GetByIdAsync(commentId))
                                  .ReturnsAsync((Comment)null);

            // Act
            var result = await _commentService.GetByIdAsync(commentId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Comment not found.", notFoundResult.Value.GetType().GetProperty("message").GetValue(notFoundResult.Value).ToString());
        }

        [Fact]
        public async Task DeleteAsync_CommentNotFound_ReturnsNotFound()
        {
            // Arrange
            var commentId = 1;
            _commentRepositoryMock.Setup(repo => repo.GetByIdAsync(commentId))
                                  .ReturnsAsync((Comment)null);

            // Act
            var result = await _commentService.DeleteAsync(commentId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Comment not found.", notFoundResult.Value.GetType().GetProperty("message").GetValue(notFoundResult.Value).ToString());
        }
    }
}
