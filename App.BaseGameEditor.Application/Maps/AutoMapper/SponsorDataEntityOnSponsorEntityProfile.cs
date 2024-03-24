using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Domain.Entities;
using AutoMapper;

namespace App.BaseGameEditor.Application.Maps.AutoMapper
{
    public class SponsorDataEntityOnSponsorEntityProfile : Profile
    {
        public SponsorDataEntityOnSponsorEntityProfile()
        {
            CreateMap<SponsorDataEntity, SponsorEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));

            CreateMap<SponsorContractDataEntity, SponsorContractEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());

            CreateMap<SponsorFiaDataEntity, SponsorFiaEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));
        }
    }
}