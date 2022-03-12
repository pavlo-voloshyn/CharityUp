using AccountService.Application.Models;
using AccountService.Domain.Models;
using AutoMapper;

namespace AccountService.Application.MapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<SignUpRequestModel, User>()
            .ForMember(dst => dst.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dst => dst.CreatedDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dst => dst.EmailConfirmed, opt => opt.MapFrom(_ => true))
            .ForMember(dst => dst.PhoneNumber, opt => opt.MapFrom(_ => true));
        CreateMap<User, SignUpResponseModel>();

        CreateMap<LogInRequestModel, User>();
        CreateMap<User, LogInResponseModel>();
        CreateMap<User, UserModel>();
    }
}
