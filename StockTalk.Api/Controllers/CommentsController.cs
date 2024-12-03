using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using StockTalk.Entities.DTOs.CommentDto;
using StockTalk.Entities.DTOs.StockDto;
using StockTalk.Entities.Models;
using StockTalk.Infrastructure.Data_Access;
using StockTalk.Service.Services;

namespace StockTalk.Api.Controllers
{
    [Authorize]
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentsController(CommentService commentService)
        {
            _commentService = commentService;
        }

        // GET: api/comments
        [HttpGet]
        [EnableQuery]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(IQueryable<ToCommentDto>), 200)]
        public async Task<IActionResult> GetStockComments(int stockId)
        {
            return await _commentService.GetStockCommentsAsync(stockId);
        }

        // POST: api/comments
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto createCommentDto)
        {
            return await _commentService.CreateAsync(createCommentDto);
        }

        // GET: api/comments/5
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetComment(int id)
        {
            return await _commentService.GetByIdAsync(id);
        }

        // PUT: api/comments/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateComment(int id, UpdateCommentDto updateCommentDto)
        {
            return await _commentService.UpdateAsync(id, updateCommentDto);
        }

        // DELETE: api/comments/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteComment(int id)
        {
            return await _commentService.DeleteAsync(id);
        }
    }
}
