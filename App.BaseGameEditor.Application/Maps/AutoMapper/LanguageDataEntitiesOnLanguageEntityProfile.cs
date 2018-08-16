using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Domain.Entities;
using AutoMapper;

namespace App.BaseGameEditor.Application.Maps.AutoMapper
{
    public class LanguageDataEntitiesOnLanguageEntityProfile : Profile
    {
        public LanguageDataEntitiesOnLanguageEntityProfile()
        {
            CreateMap<LanguageDataEntity, LanguageEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());
        }
    }
}