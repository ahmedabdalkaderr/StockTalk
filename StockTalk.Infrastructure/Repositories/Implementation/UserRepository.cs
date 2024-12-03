using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StockTalk.Entities.DTOs.UserDto;
using StockTalk.Entities.Models;
using StockTalk.Infrastructure.Repositories.Interfaces;

namespace StockTalk.Infrastructure.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterDto model)
        {
            var user = _mapper.Map<User>(model);
            return await _userManager.CreateAsync(user, model.Password);
        }

        public async Task<User> LoginUserAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return null; 
            }
            return user;
        }
    }
}

