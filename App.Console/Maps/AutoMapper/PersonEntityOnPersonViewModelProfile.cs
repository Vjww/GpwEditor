using App.BaseGameEditor.Domain.Entities;
using App.Console.ViewModels;
using AutoMapper;

namespace App.Console.Maps.AutoMapper
{
    public class PersonEntityOnPersonViewModelProfile : Profile, IAutoMapperPresentationProfile
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

            CreateMap<NonF1ChiefCommercialEntity, NonF1ChiefCommercialViewModel>()
                .ReverseMap();

            CreateMap<NonF1ChiefDesignerEntity, NonF1ChiefDesignerViewModel>()
                .ReverseMap();

            CreateMap<NonF1ChiefEngineerEntity, NonF1ChiefEngineerViewModel>()
                .ReverseMap();

            CreateMap<NonF1ChiefMechanicEntity, NonF1ChiefMechanicViewModel>()
                .ReverseMap();

            CreateMap<NonF1DriverEntity, NonF1DriverViewModel>()
                .ReverseMap();
        }
    }
}