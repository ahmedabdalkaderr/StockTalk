using Microsoft.AspNetCore.Mvc;
using StockTalk.Entities.DTOs.StockUser;
using StockTalk.Service.Services;

namespace StockTalk.Api.Controllers
{
    [Route("api/stockusers")]
    [ApiController]
    public class StockUserController : ControllerBase
    {
        private readonly StockUserService _stockUserService;

        public StockUserController(StockUserService stockUserService)
        {
            _stockUserService = stockUserService;
        }

        // POST: api/stockusers
        [HttpPost]
        public async Task<IActionResult> CreateStockUser([FromBody] CreateStockUserDto dto)
        {
            var stockUser = await _stockUserService.CreateStockUserAsync(dto.StockId, dto.UserId);
            return Ok(stockUser);
        }

        // GET: api/stockusers
        [HttpGet]
        public async Task<IActionResult> GetStockUsers()
        {
            var stockUsers = await _stockUserService.GetStockUsersAsync();
            return Ok(stockUsers);
        }
    }

}
