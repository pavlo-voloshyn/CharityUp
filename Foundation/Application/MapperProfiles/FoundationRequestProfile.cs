using Application.Models;
using AutoMapper;
using Domain.Models;

namespace Application.MapperProfiles;

public class FoundationRequestProfile : Profile
{
    public FoundationRequestProfile()
    {
        CreateMap<FoundationRequestInsertModel, FoundationRequest>()
            .ForMember(dst => dst.DateOfRequesting, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<FoundationRequestUpdateModel, FoundationRequest>();
        CreateMap<FoundationRequest, FoundationRequestViewModel>();
    }
}
