using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTalk.Entities.DTOs.CommentDto;
using StockTalk.Entities.Models;
using StockTalk.Infrastructure.Repositories.Interfaces;

namespace StockTalk.Service.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IStockRepository stockRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        public async Task<bool> StockExist(int stockId)
        {
            var stock = await _stockRepository.GetByIdAsync(stockId);
            if (stock == null)
            {
                return false;
            }
            return true;
        }

        public async Task<IActionResult> GetStockCommentsAsync(int stockId) {
            var stock = await StockExist(stockId);
            Console.WriteLine(stock);
            if (stock == false) { 
                return new NotFoundObjectResult(new { message = "Stock not found." }); 
            } 
            var comments = await _commentRepository.GetAsync(stockId);
            var commentDtos = _mapper.Map<IEnumerable<ToCommentDto>>(comments); 
            return new OkObjectResult(commentDtos);
        }

        public async Task<IActionResult> CreateAsync(CreateCommentDto createCommentDto)
        {
            var stock = await _stockRepository.GetByIdAsync(createCommentDto.StockId);
            if (stock == null) {
                return new NotFoundObjectResult(new { message = "Stock not found." });
            }
            var comment = _mapper.Map<Comment>(createCommentDto);
            comment.Stock = stock;
            await _commentRepository.AddAsync(comment);
            var result = _mapper.Map<ToCommentDto>(comment);
            return new OkObjectResult(result);
        }

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);

            if (comment == null)
            {
                return new NotFoundObjectResult(new { message = "Comment not found." });
            }
            var result = _mapper.Map<ToCommentDto>(comment);
            return new OkObjectResult(result);
        }



        public async Task<IActionResult> UpdateAsync(int id, UpdateCommentDto updateCommentDto)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return new NotFoundObjectResult(new { message = "Comment not found." });
            }
            _mapper.Map(updateCommentDto, comment);
            await _commentRepository.UpdateAsync(comment);
            var result = _mapper.Map<ToCommentDto>(comment);
            return new OkObjectResult(result);
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return new NotFoundObjectResult(new { message = "Comment not found." });
            }

            await _commentRepository.DeleteAsync(comment);
            return new OkObjectResult(true);
        }
    }
}
