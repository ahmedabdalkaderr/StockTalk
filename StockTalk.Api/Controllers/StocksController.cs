using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using StockTalk.Entities.DTOs.StockDto;
using StockTalk.Service.Services;

namespace StockTalk.Api.Controllers
{
    [Authorize]
    [Route("api/stocks")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly StockService _stockService;

        public StocksController(StockService stockService)
        {
            _stockService = stockService;
        }

        // GET: api/stocks
        [EnableQuery]
        [HttpGet]
        [ProducesResponseType(typeof(IQueryable<ToStockDto>), 200)]
        public async Task<IEnumerable<ToStockDto>> GetAllStocks()
        {
            return await _stockService.GetAllAsync();
        }

        // GET: api/stocks/5
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetStock(int id)
        {
            return await _stockService.GetByIdAsync(id);
        }

        // POST: api/stocks
        [HttpPost]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockDto createStockDto)
        {   
            return await _stockService.CreateAsync(createStockDto);
        }

        // PUT: api/stocks/5
        [HttpPut("{id}")]
        [ProducesResponseType(400)] 
        [ProducesResponseType(404)] 
        public async Task<IActionResult> UpdateStock(int id, [FromBody] UpdateStockDto updateStockDto)
        {
            return await _stockService.UpdateAsync(id, updateStockDto);
        }

        // DELETE: api/stocks/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)] 
        [ProducesResponseType(404)] 
        public async Task<IActionResult> DeleteStock(int id)
        {
           return await _stockService.DeleteAsync(id);
        }
    }
}
