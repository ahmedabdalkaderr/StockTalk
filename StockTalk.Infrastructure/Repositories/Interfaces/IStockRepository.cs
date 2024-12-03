using System.Collections.Generic;
using System.Threading.Tasks;
using StockTalk.Entities.Models;

namespace StockTalk.Infrastructure.Repositories.Interfaces
{
    public interface IStockRepository
    {
        Task<IEnumerable<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> AddAsync(Stock stock);
        Task<Stock> UpdateAsync(Stock stock);
        Task<bool> DeleteAsync(Stock stock);
    }
}
