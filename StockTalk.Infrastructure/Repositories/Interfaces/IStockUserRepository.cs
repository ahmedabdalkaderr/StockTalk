using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTalk.Entities.Models;

namespace StockTalk.Infrastructure.Repositories.Interfaces
{
    public interface IStockUserRepository
    {
        Task<StockUser> CreateStockUserAsync(int stockId, string userId);
        Task<IEnumerable<StockUser>> GetStockUsersAsync();
    }

}
