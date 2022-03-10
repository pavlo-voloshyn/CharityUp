using AutoMapper;
using FoundationService.Domain.Models;
using FoundationService.Application.Models.FoundationModels;

namespace FoundationService.Application.MapperProfiles;

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
