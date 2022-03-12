using AutoMapper;
using FoundationService.Application.Models.FoundationRequestModels;
using FoundationService.Domain.Models;

namespace FoundationService.Application.MapperProfiles;

internal class FoundationRequestProfile : Profile
{
    public FoundationRequestProfile()
    {
        CreateMap<FoundationRequestInsertModel, FoundationRequest>()
            .ForMember(dst => dst.DateOfRequesting, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<FoundationRequestUpdateModel, FoundationRequest>();
        CreateMap<FoundationRequest, FoundationRequestViewModel>();
        CreateMap<FoundationRequest, Foundation>();
    }
}
