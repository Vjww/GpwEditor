using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Infrastructure.Objects;
using AutoMapper;

namespace App.BaseGameEditor.Application.Maps.AutoMapper
{
    public class TeamDataEntityOnTeamEntityProfile : Profile
    {
        public TeamDataEntityOnTeamEntityProfile()
        {
            CreateMap<TeamDataEntity, TeamEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ForMember(dest => dest.ChassisHandling, opt => opt.Ignore())
                .ForMember(dest => dest.CarNumberDriver1, opt => opt.Ignore())
                .ForMember(dest => dest.CarNumberDriver2, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));

            CreateMap<ChassisHandlingDataEntity, TeamEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.LastPosition, opt => opt.Ignore())
                .ForMember(dest => dest.LastPoints, opt => opt.Ignore())
                .ForMember(dest => dest.DebutGrandPrix, opt => opt.Ignore())
                .ForMember(dest => dest.DebutYear, opt => opt.Ignore())
                .ForMember(dest => dest.Wins, opt => opt.Ignore())
                .ForMember(dest => dest.YearlyBudget, opt => opt.Ignore())
                .ForMember(dest => dest.UnknownA, opt => opt.Ignore())
                .ForMember(dest => dest.Location, opt => opt.Ignore())
                .ForMember(dest => dest.LocationX, opt => opt.Ignore())
                .ForMember(dest => dest.LocationY, opt => opt.Ignore())
                .ForMember(dest => dest.TyreSupplier, opt => opt.Ignore())
                .ForMember(dest => dest.CarNumberDriver1, opt => opt.Ignore())
                .ForMember(dest => dest.CarNumberDriver2, opt => opt.Ignore())
                .ForMember(dest => dest.ChassisHandling, opt => opt.MapFrom(src => src.Value))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForMember(src => src.Value, opt => opt.MapFrom(dest => dest.ChassisHandling));

            CreateMap<CarNumbersObject, TeamEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.LastPosition, opt => opt.Ignore())
                .ForMember(dest => dest.LastPoints, opt => opt.Ignore())
                .ForMember(dest => dest.DebutGrandPrix, opt => opt.Ignore())
                .ForMember(dest => dest.DebutYear, opt => opt.Ignore())
                .ForMember(dest => dest.Wins, opt => opt.Ignore())
                .ForMember(dest => dest.YearlyBudget, opt => opt.Ignore())
                .ForMember(dest => dest.UnknownA, opt => opt.Ignore())
                .ForMember(dest => dest.Location, opt => opt.Ignore())
                .ForMember(dest => dest.LocationX, opt => opt.Ignore())
                .ForMember(dest => dest.LocationY, opt => opt.Ignore())
                .ForMember(dest => dest.TyreSupplier, opt => opt.Ignore())
                .ForMember(dest => dest.ChassisHandling, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());
        }
    }
}