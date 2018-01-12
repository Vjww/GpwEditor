using AutoMapper;

namespace App.BaseGameEditor.Infrastructure.AutoMapperMaps
{
    public class DataEntitiesOnTeamEntityMap : Profile
    {
        public DataEntitiesOnTeamEntityMap()
        {
            CreateMap<Data.Entities.TeamEntity, Domain.Entities.TeamEntity>()
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.All))
                .ReverseMap()
                .ForPath(src => src.Name.All, opt => opt.MapFrom(dest => dest.Name));

            CreateMap<Data.Entities.ChassisHandlingEntity, Domain.Entities.TeamEntity>()
                .ForMember(dest => dest.TeamId, opt => opt.Ignore())
                .ForMember(dest => dest.ChassisHandling, opt => opt.MapFrom(src => src.Value))
                .ReverseMap()
                .ForPath(src => src.Value, opt => opt.MapFrom(dest => dest.ChassisHandling));

            CreateMap<CarNumbersObject, Domain.Entities.TeamEntity>()
                .ReverseMap();
        }
    }
}