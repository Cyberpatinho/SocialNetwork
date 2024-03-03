using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateActivityDto, Activity>()
                .ForMember(dest => dest.Date,
                opt => opt.MapFrom(src => src.Date.ToUniversalTime()));

            CreateMap<UpdateActivityDto, Activity>()
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => src.Date.ToUniversalTime()))
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
