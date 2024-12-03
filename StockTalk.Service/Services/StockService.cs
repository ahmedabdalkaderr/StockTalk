using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTalk.Entities.DTOs.StockDto;
using StockTalk.Entities.Models;
using StockTalk.Infrastructure.Repositories.Interfaces;

namespace StockTalk.Service.Services
{
    public class StockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StockService(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ToStockDto>> GetAllAsync()
        {
            var stocks = await _stockRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ToStockDto>>(stocks);
        }

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null)
            {
                return new NotFoundObjectResult(new { message = "Stock not found." });
            }

            return new OkObjectResult(stock);
        }

        public async Task<IActionResult> CreateAsync(CreateStockDto createStockDto)
        {
            var stock = _mapper.Map<Stock>(createStockDto);
            return new OkObjectResult(await _stockRepository.AddAsync(stock));
        }

        public async Task<IActionResult> UpdateAsync(int id, UpdateStockDto updateStockDto)
        {
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
            {
                return new NotFoundObjectResult(new { message = "Stock not found." });
            }
            _mapper.Map(updateStockDto, stock);
            return new OkObjectResult(await _stockRepository.UpdateAsync(stock));
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var stock = await _stockRepository.GetByIdAsync(id);
            if (stock == null)
            {
                return new NotFoundObjectResult(new { message = "Stock not found." });
            }

            await _stockRepository.DeleteAsync(stock);
            return new OkObjectResult(true);
        }
    }
}
