using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Domain.Models;
using AutoMapper;

namespace App.BaseGameEditor.Infrastructure.Maps
{
    // TODO: Redundant? As there are classes that perform the aggregation/parting instead
    public class TeamEntityOnTeamModelMap : Profile
    {
        public TeamEntityOnTeamModelMap()
        {
            CreateMap<TeamEntity, TeamModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.All))
                .ReverseMap()
                .ForPath(src => src.Name.All, opt => opt.MapFrom(dest => dest.Name));
        }
    }
}