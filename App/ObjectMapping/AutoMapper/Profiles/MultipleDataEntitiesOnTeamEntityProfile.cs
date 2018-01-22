using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Maps;
using AutoMapper;

namespace App.ObjectMapping.AutoMapper.Profiles
{
    public class MultipleDataEntitiesOnTeamEntityProfile : Profile
    {
        public MultipleDataEntitiesOnTeamEntityProfile()
        {
            CreateMap<TeamDataEntity, TeamEntity>()
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.All))
                .ForMember(dest => dest.ChassisHandling, opt => opt.Ignore())
                .ForMember(dest => dest.CarNumberDriver1, opt => opt.Ignore())
                .ForMember(dest => dest.CarNumberDriver2, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.All, opt => opt.MapFrom(dest => dest.Name));

            CreateMap<ChassisHandlingDataEntity, TeamEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.LastPosition, opt => opt.Ignore())
                .ForMember(dest => dest.LastPoints, opt => opt.Ignore())
                .ForMember(dest => dest.FirstGpTrack, opt => opt.Ignore())
                .ForMember(dest => dest.FirstGpYear, opt => opt.Ignore())
                .ForMember(dest => dest.Wins, opt => opt.Ignore())
                .ForMember(dest => dest.YearlyBudget, opt => opt.Ignore())
                .ForMember(dest => dest.CountryMapId, opt => opt.Ignore())
                .ForMember(dest => dest.LocationPointerX, opt => opt.Ignore())
                .ForMember(dest => dest.LocationPointerY, opt => opt.Ignore())
                .ForMember(dest => dest.TyreSupplierId, opt => opt.Ignore())
                .ForMember(dest => dest.CarNumberDriver1, opt => opt.Ignore())
                .ForMember(dest => dest.CarNumberDriver2, opt => opt.Ignore())
                .ForMember(dest => dest.ChassisHandling, opt => opt.MapFrom(src => src.Value))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.TeamId, opt => opt.ResolveUsing(dest => dest.TeamId - 1))
                .ForMember(src => src.Value, opt => opt.MapFrom(dest => dest.ChassisHandling));

            CreateMap<CarNumbersObject, TeamEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.LastPosition, opt => opt.Ignore())
                .ForMember(dest => dest.LastPoints, opt => opt.Ignore())
                .ForMember(dest => dest.FirstGpTrack, opt => opt.Ignore())
                .ForMember(dest => dest.FirstGpYear, opt => opt.Ignore())
                .ForMember(dest => dest.Wins, opt => opt.Ignore())
                .ForMember(dest => dest.YearlyBudget, opt => opt.Ignore())
                .ForMember(dest => dest.CountryMapId, opt => opt.Ignore())
                .ForMember(dest => dest.LocationPointerX, opt => opt.Ignore())
                .ForMember(dest => dest.LocationPointerY, opt => opt.Ignore())
                .ForMember(dest => dest.TyreSupplierId, opt => opt.Ignore())
                .ForMember(dest => dest.ChassisHandling, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}