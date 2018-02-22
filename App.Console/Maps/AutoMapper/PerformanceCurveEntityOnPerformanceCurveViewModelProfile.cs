using App.BaseGameEditor.Domain.Entities;
using App.Console.ViewModels;
using AutoMapper;

namespace App.Console.Maps.AutoMapper
{
    public class PerformanceCurveEntityOnPerformanceCurveViewModelProfile : Profile, IAutoMapperPresentationProfile
    {
        public PerformanceCurveEntityOnPerformanceCurveViewModelProfile()
        {
            CreateMap<PerformanceCurveEntity, PerformanceCurveViewModel>()
                .ReverseMap();
        }
    }
}