using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Presentation.ViewModels;
using AutoMapper;

namespace App.ObjectMapping.AutoMapper.Profiles
{
    public class PersonEntityOnPersonViewModelProfile : Profile
    {
        public PersonEntityOnPersonViewModelProfile()
        {
            CreateMap<F1ChiefCommercialEntity, F1ChiefCommercialViewModel>()
                .ReverseMap();
        }
    }
}