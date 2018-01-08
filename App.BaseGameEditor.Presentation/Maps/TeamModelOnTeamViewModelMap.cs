using App.BaseGameEditor.Domain.Models;
using App.BaseGameEditor.Presentation.ViewModels;
using AutoMapper;

namespace App.BaseGameEditor.Presentation.Maps
{
    public class TeamModelOnTeamViewModelMap : Profile
    {
        public TeamModelOnTeamViewModelMap()
        {
            CreateMap<TeamModel, TeamViewModel>()
                .ReverseMap();
        }
    }
}