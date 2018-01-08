using App.BaseGameEditor.Domain.Models;
using AutoMapper;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace App.BaseGameEditor.Infrastructure.Maps
{
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