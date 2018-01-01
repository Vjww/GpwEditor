using AutoMapper;
using GpwEditor.Domain.Models.BaseGame;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Application.Maps
{
    public class TeamEntityOnTeamModelMap : Profile
    {
        public TeamEntityOnTeamModelMap()
        {
            CreateMap<TeamEntity, ITeamModel>();
            CreateMap<ITeamModel, TeamEntity>();
        }
    }
}