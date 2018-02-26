using App.BaseGameEditor.Data.DataEntities.Lookups;
using App.BaseGameEditor.Domain.Entities.Lookups;
using AutoMapper;

namespace App.BaseGameEditor.Application.Maps.AutoMapper
{
    public class LookupDataEntitiesOnLookupEntityProfile : Profile
    {
        public LookupDataEntitiesOnLookupEntityProfile()
        {
            CreateMap<ChiefDriverLoyaltyLookupDataEntity, ChiefDriverLoyaltyLookupEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());

            CreateMap<DriverNationalityLookupDataEntity, DriverNationalityLookupEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());

            CreateMap<TeamDebutGrandPrixLookupDataEntity, TeamDebutGrandPrixLookupEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());

            CreateMap<TrackFastestLapDriverLookupDataEntity, TrackFastestLapDriverLookupEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());

            CreateMap<TrackLayoutLookupDataEntity, TrackLayoutLookupEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());

            CreateMap<TyreSupplierLookupDataEntity, TyreSupplierLookupEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());
        }
    }
}