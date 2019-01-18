// TODO: Is this redundant? Superseded by SponsorDataEntity?

//using App.BaseGameEditor.Data.DataEntities;
//using App.BaseGameEditor.Domain.Entities;
//using AutoMapper;

//namespace App.BaseGameEditor.Application.Maps.AutoMapper
//{
//    public class SponsorshipDataEntitiesOnSponsorshipEntityProfile : Profile
//    {
//        public SponsorshipDataEntitiesOnSponsorshipEntityProfile()
//        {
//            CreateMap<SponsorshipTeamDataEntity, SponsorTeamEntity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore())
//                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));

//            CreateMap<SponsorshipEngineDataEntity, SponsorEngineEntity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore())
//                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));

//            CreateMap<SponsorshipTyreDataEntity, SponsorTyreEntity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore())
//                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));

//            CreateMap<SponsorshipFuelDataEntity, SponsorFuelEntity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore())
//                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));

//            CreateMap<SponsorshipCashDataEntity, SponsorCashEntity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore())
//                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));

//            CreateMap<SponsorshipContractTeam01DataEntity, SponsorshipContractTeam01Entity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore());

//            CreateMap<SponsorshipContractTeam02DataEntity, SponsorshipContractTeam02Entity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore());

//            CreateMap<SponsorshipContractTeam03DataEntity, SponsorshipContractTeam03Entity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore());

//            CreateMap<SponsorshipContractTeam04DataEntity, SponsorshipContractTeam04Entity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore());

//            CreateMap<SponsorshipContractTeam05DataEntity, SponsorshipContractTeam05Entity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore());

//            CreateMap<SponsorshipContractTeam06DataEntity, SponsorshipContractTeam06Entity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore());

//            CreateMap<SponsorshipContractTeam07DataEntity, SponsorshipContractTeam07Entity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore());

//            CreateMap<SponsorshipContractTeam08DataEntity, SponsorshipContractTeam08Entity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore());

//            CreateMap<SponsorshipContractTeam09DataEntity, SponsorshipContractTeam09Entity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore());

//            CreateMap<SponsorshipContractTeam10DataEntity, SponsorshipContractTeam10Entity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore());

//            CreateMap<SponsorshipContractTeam11DataEntity, SponsorshipContractTeam11Entity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore());
//        }
//    }
//}