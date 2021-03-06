﻿using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Domain.Entities;
using AutoMapper;

namespace App.BaseGameEditor.Application.Maps.AutoMapper
{
    public class TrackDataEntitiesOnTrackEntityProfile : Profile
    {
        public TrackDataEntitiesOnTrackEntityProfile()
        {
            CreateMap<TrackDataEntity, TrackEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));
        }
    }
}