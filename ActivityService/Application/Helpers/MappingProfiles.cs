using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateActivityDto, Activity>();
            CreateMap<UpdateActivityDto, Activity>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
