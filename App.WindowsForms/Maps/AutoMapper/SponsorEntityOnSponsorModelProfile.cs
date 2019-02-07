using App.BaseGameEditor.Domain.Entities;
using App.WindowsForms.Models;
using AutoMapper;

namespace App.WindowsForms.Maps.AutoMapper
{
    public class SponsorEntityOnSponsorModelProfile : Profile
    {
        public SponsorEntityOnSponsorModelProfile()
        {
            CreateMap<SponsorEntity, SponsorModel>()
                .ReverseMap();

            CreateMap<SponsorContractEntity, SponsorContractModel>()
                .ForMember(src => src.SlotDescription, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<SponsorFiaEntity, SponsorFiaModel>()
                .ReverseMap();
        }
    }
}