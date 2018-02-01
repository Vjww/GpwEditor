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

            CreateMap<F1ChiefDesignerEntity, F1ChiefDesignerViewModel>()
                .ReverseMap();

            CreateMap<F1ChiefEngineerEntity, F1ChiefEngineerViewModel>()
                .ReverseMap();

            CreateMap<F1ChiefMechanicEntity, F1ChiefMechanicViewModel>()
                .ReverseMap();

            CreateMap<F1DriverEntity, F1DriverViewModel>()
                .ReverseMap();
        }
    }
}