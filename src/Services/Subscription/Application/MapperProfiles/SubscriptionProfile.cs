using AutoMapper;
using SubscriptionService.Domain.Models;
using SubscriptionService.Application.Models;

namespace SubscriptionService.Application.MapperProfiles;

internal class SubscriptionProfile : Profile
{
    public SubscriptionProfile()
    {
        CreateMap<Subscription, SubscriptionViewModel>();
        CreateMap<SubscriptionInsertModel, Subscription>()
            .ForMember(dst => dst.DateSubscribed, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<SubscriptionUpdateModel, Subscription>();
    }
}
