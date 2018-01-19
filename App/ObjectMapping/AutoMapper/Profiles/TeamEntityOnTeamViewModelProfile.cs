using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Presentation.ViewModels;
using AutoMapper;

namespace App.ObjectMapping.AutoMapper.Profiles
{
    public class TeamEntityOnTeamViewModelProfile : Profile
    {
        public TeamEntityOnTeamViewModelProfile()
        {
            CreateMap<TeamEntity, TeamViewModel>()
                .ReverseMap();
        }
    }
}