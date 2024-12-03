using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTalk.Entities.Models;
using StockTalk.Infrastructure.Repositories.Interfaces;

namespace StockTalk.Service.Services
{
    public class StockUserService
    {
        private readonly IStockUserRepository _stockUserRepository;

        public StockUserService(IStockUserRepository stockUserRepository)
        {
            _stockUserRepository = stockUserRepository;
        }

        public async Task<StockUser> CreateStockUserAsync(int stockId, string userId)
        {
            return await _stockUserRepository.CreateStockUserAsync(stockId, userId);
        }

        public async Task<IEnumerable<StockUser>> GetStockUsersAsync()
        {
            return await _stockUserRepository.GetStockUsersAsync();
        }
    }

}
