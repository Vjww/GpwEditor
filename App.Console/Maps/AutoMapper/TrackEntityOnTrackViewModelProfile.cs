using App.BaseGameEditor.Domain.Entities;
using App.Console.ViewModels;
using AutoMapper;

namespace App.Console.Maps.AutoMapper
{
    public class TrackEntityOnTrackViewModelProfile : Profile, IAutoMapperPresentationProfile
    {
        public TrackEntityOnTrackViewModelProfile()
        {
            CreateMap<TrackEntity, TrackViewModel>()
                .ReverseMap();
        }
    }
}