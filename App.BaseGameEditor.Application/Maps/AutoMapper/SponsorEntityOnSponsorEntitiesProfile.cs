﻿// TODO: Is this redundant? Superseded by SponsorDataEntity?

//using App.BaseGameEditor.Domain.Entities;
//using AutoMapper;

//namespace App.BaseGameEditor.Application.Maps.AutoMapper
//{
//    public class SponsorEntityOnSponsorEntitiesProfile : Profile
//    {
//        public SponsorEntityOnSponsorEntitiesProfile()
//        {
//            CreateMap<SponsorEntity, SponsorTeamEntity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore())
//                //.ForMember(src => src.CashRating, opt => opt.Ignore())
//                .ForMember(src => src.CashRatingRandom, opt => opt.Ignore())
//                .ForMember(src => src.RadRating, opt => opt.Ignore())
//                .ForMember(src => src.RadRatingRandom, opt => opt.Ignore())
//                .ForMember(src => src.Inactive, opt => opt.Ignore())
//                .ForMember(src => src.Fuel, opt => opt.Ignore())
//                .ForMember(src => src.Heat, opt => opt.Ignore())
//                .ForMember(src => src.Power, opt => opt.Ignore())
//                .ForMember(src => src.Reliability, opt => opt.Ignore())
//                .ForMember(src => src.Response, opt => opt.Ignore())
//                .ForMember(src => src.Rigidity, opt => opt.Ignore())
//                .ForMember(src => src.Weight, opt => opt.Ignore())
//                .ForMember(src => src.DryHardGrip, opt => opt.Ignore())
//                .ForMember(src => src.DryHardResilience, opt => opt.Ignore())
//                .ForMember(src => src.DryHardStiffness, opt => opt.Ignore())
//                .ForMember(src => src.DryHardTemperature, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftGrip, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftResilience, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftStiffness, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftTemperature, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateGrip, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateResilience, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateStiffness, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateTemperature, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherGrip, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherResilience, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherStiffness, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherTemperature, opt => opt.Ignore())
//                .ForMember(src => src.Performance, opt => opt.Ignore())
//                .ForMember(src => src.Tolerance, opt => opt.Ignore());

//            CreateMap<SponsorEntity, SponsorEngineEntity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore())
//                //.ForMember(src => src.CashRating, opt => opt.Ignore())
//                //.ForMember(src => src.CashRatingRandom, opt => opt.Ignore())
//                //.ForMember(src => src.RadRating, opt => opt.Ignore())
//                //.ForMember(src => src.RadRatingRandom, opt => opt.Ignore())
//                //.ForMember(src => src.Inactive, opt => opt.Ignore())
//                //.ForMember(src => src.Fuel, opt => opt.Ignore())
//                //.ForMember(src => src.Heat, opt => opt.Ignore())
//                //.ForMember(src => src.Power, opt => opt.Ignore())
//                //.ForMember(src => src.Reliability, opt => opt.Ignore())
//                //.ForMember(src => src.Response, opt => opt.Ignore())
//                //.ForMember(src => src.Rigidity, opt => opt.Ignore())
//                //.ForMember(src => src.Weight, opt => opt.Ignore())
//                .ForMember(src => src.DryHardGrip, opt => opt.Ignore())
//                .ForMember(src => src.DryHardResilience, opt => opt.Ignore())
//                .ForMember(src => src.DryHardStiffness, opt => opt.Ignore())
//                .ForMember(src => src.DryHardTemperature, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftGrip, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftResilience, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftStiffness, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftTemperature, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateGrip, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateResilience, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateStiffness, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateTemperature, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherGrip, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherResilience, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherStiffness, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherTemperature, opt => opt.Ignore())
//                .ForMember(src => src.Performance, opt => opt.Ignore())
//                .ForMember(src => src.Tolerance, opt => opt.Ignore());

//            CreateMap<SponsorEntity, SponsorTyreEntity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore())
//                //.ForMember(src => src.CashRating, opt => opt.Ignore())
//                //.ForMember(src => src.CashRatingRandom, opt => opt.Ignore())
//                //.ForMember(src => src.RadRating, opt => opt.Ignore())
//                //.ForMember(src => src.RadRatingRandom, opt => opt.Ignore())
//                //.ForMember(src => src.Inactive, opt => opt.Ignore())
//                .ForMember(src => src.Fuel, opt => opt.Ignore())
//                .ForMember(src => src.Heat, opt => opt.Ignore())
//                .ForMember(src => src.Power, opt => opt.Ignore())
//                .ForMember(src => src.Reliability, opt => opt.Ignore())
//                .ForMember(src => src.Response, opt => opt.Ignore())
//                .ForMember(src => src.Rigidity, opt => opt.Ignore())
//                .ForMember(src => src.Weight, opt => opt.Ignore())
//                //.ForMember(src => src.DryHardGrip, opt => opt.Ignore())
//                //.ForMember(src => src.DryHardResilience, opt => opt.Ignore())
//                //.ForMember(src => src.DryHardStiffness, opt => opt.Ignore())
//                //.ForMember(src => src.DryHardTemperature, opt => opt.Ignore())
//                //.ForMember(src => src.DrySoftGrip, opt => opt.Ignore())
//                //.ForMember(src => src.DrySoftResilience, opt => opt.Ignore())
//                //.ForMember(src => src.DrySoftStiffness, opt => opt.Ignore())
//                //.ForMember(src => src.DrySoftTemperature, opt => opt.Ignore())
//                //.ForMember(src => src.IntermediateGrip, opt => opt.Ignore())
//                //.ForMember(src => src.IntermediateResilience, opt => opt.Ignore())
//                //.ForMember(src => src.IntermediateStiffness, opt => opt.Ignore())
//                //.ForMember(src => src.IntermediateTemperature, opt => opt.Ignore())
//                //.ForMember(src => src.WetWeatherGrip, opt => opt.Ignore())
//                //.ForMember(src => src.WetWeatherResilience, opt => opt.Ignore())
//                //.ForMember(src => src.WetWeatherStiffness, opt => opt.Ignore())
//                //.ForMember(src => src.WetWeatherTemperature, opt => opt.Ignore())
//                .ForMember(src => src.Performance, opt => opt.Ignore())
//                .ForMember(src => src.Tolerance, opt => opt.Ignore());

//            CreateMap<SponsorEntity, SponsorFuelEntity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore())
//                //.ForMember(src => src.CashRating, opt => opt.Ignore())
//                //.ForMember(src => src.CashRatingRandom, opt => opt.Ignore())
//                //.ForMember(src => src.RadRating, opt => opt.Ignore())
//                //.ForMember(src => src.RadRatingRandom, opt => opt.Ignore())
//                //.ForMember(src => src.Inactive, opt => opt.Ignore())
//                .ForMember(src => src.Fuel, opt => opt.Ignore())
//                .ForMember(src => src.Heat, opt => opt.Ignore())
//                .ForMember(src => src.Power, opt => opt.Ignore())
//                .ForMember(src => src.Reliability, opt => opt.Ignore())
//                .ForMember(src => src.Response, opt => opt.Ignore())
//                .ForMember(src => src.Rigidity, opt => opt.Ignore())
//                .ForMember(src => src.Weight, opt => opt.Ignore())
//                .ForMember(src => src.DryHardGrip, opt => opt.Ignore())
//                .ForMember(src => src.DryHardResilience, opt => opt.Ignore())
//                .ForMember(src => src.DryHardStiffness, opt => opt.Ignore())
//                .ForMember(src => src.DryHardTemperature, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftGrip, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftResilience, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftStiffness, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftTemperature, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateGrip, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateResilience, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateStiffness, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateTemperature, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherGrip, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherResilience, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherStiffness, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherTemperature, opt => opt.Ignore());
//                //.ForMember(src => src.Performance, opt => opt.Ignore())
//                //.ForMember(src => src.Tolerance, opt => opt.Ignore())

//            CreateMap<SponsorEntity, SponsorCashEntity>()
//                .ForMember(dest => dest.Id, opt => opt.Ignore())
//                .ReverseMap()
//                .ForMember(src => src.Id, opt => opt.Ignore())
//                //.ForMember(src => src.CashRating, opt => opt.Ignore())
//                .ForMember(src => src.CashRatingRandom, opt => opt.Ignore())
//                .ForMember(src => src.RadRating, opt => opt.Ignore())
//                .ForMember(src => src.RadRatingRandom, opt => opt.Ignore())
//                .ForMember(src => src.Inactive, opt => opt.Ignore())
//                .ForMember(src => src.Fuel, opt => opt.Ignore())
//                .ForMember(src => src.Heat, opt => opt.Ignore())
//                .ForMember(src => src.Power, opt => opt.Ignore())
//                .ForMember(src => src.Reliability, opt => opt.Ignore())
//                .ForMember(src => src.Response, opt => opt.Ignore())
//                .ForMember(src => src.Rigidity, opt => opt.Ignore())
//                .ForMember(src => src.Weight, opt => opt.Ignore())
//                .ForMember(src => src.DryHardGrip, opt => opt.Ignore())
//                .ForMember(src => src.DryHardResilience, opt => opt.Ignore())
//                .ForMember(src => src.DryHardStiffness, opt => opt.Ignore())
//                .ForMember(src => src.DryHardTemperature, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftGrip, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftResilience, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftStiffness, opt => opt.Ignore())
//                .ForMember(src => src.DrySoftTemperature, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateGrip, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateResilience, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateStiffness, opt => opt.Ignore())
//                .ForMember(src => src.IntermediateTemperature, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherGrip, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherResilience, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherStiffness, opt => opt.Ignore())
//                .ForMember(src => src.WetWeatherTemperature, opt => opt.Ignore())
//                .ForMember(src => src.Performance, opt => opt.Ignore())
//                .ForMember(src => src.Tolerance, opt => opt.Ignore());
//        }
//    }
//}