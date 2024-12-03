using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StockTalk.Entities.DTOs.UserDto;
using StockTalk.Service.Services;
namespace StockTalk.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly UserService _userService;
        public UserController(UserService userService) {
            _userService = userService;
        }
        // POST: api/users/Register
        [HttpPost("Register")]
        [ProducesResponseType(400)]
        public async Task<IdentityResult> Register([FromBody] RegisterDto model)
        {
            return  await _userService.RegisterUserAsync(model);
        }

        // POST: api/Account/Login
        [HttpPost("Login")]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            return await _userService.LoginUserAsync(model);
        }
    }
}
