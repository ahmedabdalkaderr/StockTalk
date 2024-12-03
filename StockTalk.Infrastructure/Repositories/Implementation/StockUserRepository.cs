using Microsoft.EntityFrameworkCore;
using StockTalk.Entities.Models;
using StockTalk.Infrastructure.Data_Access;
using StockTalk.Infrastructure.Repositories.Interfaces;

namespace StockTalk.Infrastructure.Repositories.Implementation
{
    public class StockUserRepository : IStockUserRepository
    {
        private readonly ApplicationDBContext _context;

        public StockUserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<StockUser> CreateStockUserAsync(int stockId, string userId)
        {
            var stockUser = new StockUser
            {
                StockId = stockId,
                UserId = userId
            };

            _context.StockUsers.Add(stockUser);
            await _context.SaveChangesAsync();
            return stockUser;
        }

        public async Task<IEnumerable<StockUser>> GetStockUsersAsync()
        {
            return await _context.StockUsers
                .Include(su => su.Stock)
                .Include(su => su.User)
                .ToListAsync();
        }
    }

}
