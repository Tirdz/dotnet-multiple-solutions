using AutoMapper;
using Hello.World.Common.Dtos;
using Hello.World.DataAccess.Entities;

namespace Hello.World.Business.Common.Mappings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SampleEntity, SampleDto>();
    }
}
