using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Domain.Entities;
using AutoMapper;

namespace App.BaseGameEditor.Application.Maps.AutoMapper
{
    public class PerformanceCurveDataEntitiesOnPerformanceCurveEntityProfile : Profile
    {
        public PerformanceCurveDataEntitiesOnPerformanceCurveEntityProfile()
        {
            CreateMap<PerformanceCurveDataEntity, PerformanceCurveEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());
        }
    }
}