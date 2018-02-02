using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Presentation.ViewModels;
using AutoMapper;

namespace App.BaseGameEditor.Presentation.Maps
{
    public class TeamEntityOnTeamViewModelProfile : Profile, IAutoMapperPresentationProfile
    {
        public TeamEntityOnTeamViewModelProfile()
        {
            CreateMap<TeamEntity, TeamViewModel>()
                .ReverseMap();
        }
    }
}