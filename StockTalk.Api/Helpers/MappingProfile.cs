using AutoMapper;
using StockTalk.Entities.DTOs.CommentDto;
using StockTalk.Entities.DTOs.StockDto;
using StockTalk.Entities.DTOs.UserDto;
using StockTalk.Entities.Models;

namespace StockTalk.Api.Helpers
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)); // Map properties explicitly if necessary
            CreateMap<Stock, ToStockDto>();
            CreateMap<Comment, ToCommentDto>().ForMember(dest => dest.StockCompanyName, opt => CreateMap<CreateCommentDto, Comment>());
            CreateMap<UpdateCommentDto, Comment>()
               .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<CreateStockDto, Stock>();
            CreateMap<UpdateStockDto, Stock>()
              .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); // Map only non-null properties
        }
    }
}
