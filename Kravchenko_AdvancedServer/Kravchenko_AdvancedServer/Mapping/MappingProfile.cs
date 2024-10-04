using AutoMapper;
using Kravchenko_AdvancedServer.Models;
using Kravchenko_AdvancedServer.Models.DTOs;
using Kravchenko_AdvancedServer.Models.Responses;
using Kravchenko_AdvancedServer.Models.View;

namespace Kravchenko_AdvancedServer.Mapping;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<RegisterUserDto, User>();
        CreateMap<User, LoginUserDto>().ReverseMap().ForMember(a => a.Id, b => b.MapFrom(a => a.Id));
        CreateMap<News,GetNewsOutDto>().ForMember(a => a.Id, b => b.MapFrom(a => a.Id))
            .ForMember(a => a.Tags, b => b.MapFrom(a => a.Tags))
            .ForMember(a => a.UserId, b => b.MapFrom(u => u.User.Id))
            .ForMember(a => a.Username, b => b.MapFrom(u => u.User.Name));
        CreateMap<Tag, TagsDto>();
        CreateMap<User, GetNewsOutDto>();
        CreateMap<PutUserDto, PutUserDtoResponse>();
        CreateMap<User, PublicUserView>();
        CreateMap<NewsDto, News>();
    }
}