using AutoMapper;
using EventOne.DTO;
using EventOne.Models;

namespace EventOne.MappingProfiles;

public sealed class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateDriverDto, Drivers>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}