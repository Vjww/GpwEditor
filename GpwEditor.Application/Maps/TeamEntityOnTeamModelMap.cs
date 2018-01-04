using AutoMapper;
using GpwEditor.Domain.Models.BaseGame;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Application.Maps
{
    public class TeamEntityOnTeamModelMap : Profile
    {
        public TeamEntityOnTeamModelMap()
        {
            CreateMap<TeamEntity, ITeamModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.All))
                .ReverseMap()
                .ForPath(src => src.Name.All, opt => opt.MapFrom(dest => dest.Name));
        }
    }
}