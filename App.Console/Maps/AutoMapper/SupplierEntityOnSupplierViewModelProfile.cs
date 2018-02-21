using App.BaseGameEditor.Domain.Entities;
using App.Console.ViewModels;
using AutoMapper;

namespace App.Console.Maps.AutoMapper
{
    public class SupplierEntityOnSupplierViewModelProfile : Profile, IAutoMapperPresentationProfile
    {
        public SupplierEntityOnSupplierViewModelProfile()
        {
            CreateMap<EngineEntity, EngineViewModel>()
                .ReverseMap();

            CreateMap<TyreEntity, TyreViewModel>()
                .ReverseMap();

            CreateMap<FuelEntity, FuelViewModel>()
                .ReverseMap();
        }
    }
}