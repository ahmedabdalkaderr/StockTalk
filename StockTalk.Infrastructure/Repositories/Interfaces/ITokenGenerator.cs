using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using StockTalk.Entities.DTOs.JwtDto;
using StockTalk.Entities.Models;

namespace StockTalk.Infrastructure.Repositories.Interfaces
{
    public interface ITokenGenerator
    {
        Task<TokenDto> CreateToken(User user);
    }
}
