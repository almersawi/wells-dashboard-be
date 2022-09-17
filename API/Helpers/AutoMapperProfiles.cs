using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Well, WellDto>(); // Get 
            CreateMap<WellDto, Well>(); // Update
            CreateMap<AddWellDto, Well>();

            CreateMap<Schematic, WellSchematicDto>();
            CreateMap<WellSchematicDto, Schematic>();

            CreateMap<Trajectory, TrajectoryDto>();
            CreateMap<TrajectoryDto, Trajectory>();
        }
    }
}