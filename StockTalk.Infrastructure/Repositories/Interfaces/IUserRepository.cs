using Microsoft.AspNetCore.Identity;
using StockTalk.Entities.DTOs.UserDto;
using StockTalk.Entities.Models;

namespace StockTalk.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> RegisterUserAsync(RegisterDto model);
        Task<User> LoginUserAsync(LoginDto model);
    }
}
