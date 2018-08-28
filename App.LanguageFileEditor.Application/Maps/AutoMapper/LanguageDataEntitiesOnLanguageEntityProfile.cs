using App.LanguageFileEditor.Data.DataEntities;
using App.LanguageFileEditor.Domain.Entities;
using AutoMapper;

namespace App.LanguageFileEditor.Application.Maps.AutoMapper
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