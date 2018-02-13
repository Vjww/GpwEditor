using App.BaseGameEditor.Domain.Entities;
using App.Console.ViewModels;
using AutoMapper;

namespace App.Console.Maps.AutoMapper
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