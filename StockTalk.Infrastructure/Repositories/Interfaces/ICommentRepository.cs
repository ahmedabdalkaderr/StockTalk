using System.Collections.Generic;
using System.Threading.Tasks;
using StockTalk.Entities.Models;

namespace StockTalk.Infrastructure.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment?>> GetAsync(int stockId);
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> AddAsync(Comment comment);
        Task<Comment> UpdateAsync(Comment comment);
        Task<bool> DeleteAsync(Comment comment);
    }
}
