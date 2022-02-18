using Application.Models.FoundationModels;
using AutoMapper;
using Domain.Models;

namespace Application.MapperProfiles;

internal class FoundationProfile : Profile
{
    public FoundationProfile()
    {
        CreateMap<FoundationInsertModel, Foundation>()
            .ForMember(dst => dst.DateOfApproving, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<FoundationUpdateModel, Foundation>();
        CreateMap<Foundation, FoundationViewModel>();
    }
}
