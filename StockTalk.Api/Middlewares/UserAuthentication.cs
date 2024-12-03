using Microsoft.AspNetCore.Identity;
using StockTalk.Entities.Models;

namespace StockTalk.Api.Middlewares
{

    public class UserAuthentication
    {
        private readonly RequestDelegate _next;

        public UserAuthentication(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<User> userManager)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("You're not authenticated");
                return;
            }

            var userId = context.User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value;
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("User not found");
                return;
            }

            context.Items["User"] = user;

            await _next(context);
        }
    }

}
