using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Presentation.ViewModels;
using AutoMapper;

namespace App.BaseGameEditor.Presentation.Maps
{
    public class TeamModelOnTeamViewModelMap : Profile
    {
        public TeamModelOnTeamViewModelMap()
        {
            CreateMap<TeamEntity, TeamViewModel>()
                .ReverseMap();
        }
    }
}