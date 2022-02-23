using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.MapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<LogUpRequestModel, User>()
            .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.CreatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dst => dst.EmailConfirmed, opt => opt.MapFrom(_ => true))
            .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(_ => true));
        CreateMap<User, LogUpResponseModel>();

        CreateMap<LogInRequestModel, User>();
        CreateMap<User, LogInResponseModel>();
        CreateMap<User, UserModel>();
    }
}
