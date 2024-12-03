using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockTalk.Entities.DTOs.UserDto;
using StockTalk.Entities.Models;
using StockTalk.Infrastructure.Repositories.Interfaces;

namespace StockTalk.Service.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public UserService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;   
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterDto model)
        {
            return await _userRepository.RegisterUserAsync(model);
        }

        public async Task<IActionResult> LoginUserAsync(LoginDto model)
        {
            var user = await _userRepository.LoginUserAsync(model);

            Console.WriteLine("///////////////",user);
            if (user == null)
            {
                return new BadRequestObjectResult(new { Error = "Email or password is incorrect." });
            }
            Console.WriteLine("///////////////");
            var token = await _tokenGenerator.CreateToken(user);
            return new OkObjectResult(new { Message = "Login successful!", user, token});
        }
    }
}
