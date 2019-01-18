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
                //.ForMember(dest => dest.Contracts, opt => opt.Ignore());
        }
    }
}