using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTalk.Entities.DTOs.StockDto;
using StockTalk.Entities.Models;
using StockTalk.Infrastructure.Repositories.Interfaces;
using StockTalk.Service.Services;
using Xunit;
using FluentAssertions;

namespace StockTalk.Tests
{
    public class StockServiceTests
    {
        private readonly Mock<IStockRepository> _mockStockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly StockService _stockService;
        public Stock _stock;
        public StockServiceTests()
        {
            _mockStockRepository = new Mock<IStockRepository>();
            _mockMapper = new Mock<IMapper>();
            _stockService = new StockService(_mockStockRepository.Object, _mockMapper.Object);
            _stock = new Stock
            {
                CompanyName = "Test Company",
                Purchase = 100.5m,
                LastDiv = 2.5m,
                Industry = "Technology",
                MarketCap = 1000000000
            };
        }

        [Fact]
        public async Task CreateAsync_ValidCreateStockDto_ReturnsOkResult()
        {
            // Arrange
            var createStockDto = new CreateStockDto
            {
                CompanyName = "Test Company",
                Purchase = 100.5m,
                LastDiv = 2.5m,
                Industry = "Technology",
                MarketCap = 1000000000
            };

            _mockMapper.Setup(m => m.Map<Stock>(createStockDto)).Returns(_stock);
            _mockStockRepository.Setup(r => r.AddAsync(_stock)).ReturnsAsync(_stock);

            // Act
            var result = await _stockService.CreateAsync(createStockDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnStock = Assert.IsType<Stock>(okResult.Value);
            returnStock.Should().BeEquivalentTo(createStockDto);
        }

        [Fact]
        public async Task GetByIdAsync_StockExists_ReturnsOkResult()
        {
            // Arrange
            int stockId = 1;
            _stock.Id = stockId;

            _mockStockRepository.Setup(r => r.GetByIdAsync(stockId)).ReturnsAsync(_stock);

            // Act
            var result = await _stockService.GetByIdAsync(stockId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnStock = Assert.IsType<Stock>(okResult.Value);
            Assert.Equal(stockId, returnStock.Id);
        }

        [Fact]
        public async Task GetByIdAsync_StockNotFound_ReturnsNotFoundResult()
        {
            // Arrange
            int stockId = 1;

            _mockStockRepository.Setup(r => r.GetByIdAsync(stockId)).ReturnsAsync((Stock)null);

            // Act
            var result = await _stockService.GetByIdAsync(stockId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var value = notFoundResult.Value;

            // Assert the returned message
            Assert.NotNull(value);
            Assert.Equal("Stock not found.", value.GetType().GetProperty("message").GetValue(value).ToString());
        }
    }
}
