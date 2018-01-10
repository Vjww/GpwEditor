using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Presentation.ViewModels;
using AutoMapper;

namespace App.BaseGameEditor.Presentation.Maps
{
    public class TeamEntityOnTeamViewModelMap : Profile
    {
        public TeamEntityOnTeamViewModelMap()
        {
            CreateMap<TeamEntity, TeamViewModel>()
                .ReverseMap();
        }
    }
}