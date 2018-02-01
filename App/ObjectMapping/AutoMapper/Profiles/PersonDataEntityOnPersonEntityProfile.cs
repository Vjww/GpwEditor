using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Domain.Entities;
using App.Services;
using AutoMapper;

namespace App.ObjectMapping.AutoMapper.Profiles
{
    public class PersonDataEntityOnPersonEntityProfile : Profile
    {
        public PersonDataEntityOnPersonEntityProfile(ValueConverterService valueConverterService)
        {
            if (valueConverterService == null) throw new ArgumentNullException(nameof(valueConverterService));

            CreateMap<F1ChiefCommercialDataEntity, F1ChiefCommercialEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ForMember(dest => dest.Morale, opt => opt.ResolveUsing(src => valueConverterService.ConvertToOneToFiveStepOne(src.Morale)))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.Morale, opt => opt.ResolveUsing(dest => valueConverterService.ConvertToTwentyToHundredStepTwenty(dest.Morale)));

            CreateMap<F1ChiefDesignerDataEntity, F1ChiefDesignerEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ForMember(dest => dest.Morale, opt => opt.ResolveUsing(src => valueConverterService.ConvertToOneToFiveStepOne(src.Morale)))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.Morale, opt => opt.ResolveUsing(dest => valueConverterService.ConvertToTwentyToHundredStepTwenty(dest.Morale)));

            CreateMap<F1ChiefEngineerDataEntity, F1ChiefEngineerEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ForMember(dest => dest.Morale, opt => opt.ResolveUsing(src => valueConverterService.ConvertToOneToFiveStepOne(src.Morale)))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.Morale, opt => opt.ResolveUsing(dest => valueConverterService.ConvertToTwentyToHundredStepTwenty(dest.Morale)));

            CreateMap<F1ChiefMechanicDataEntity, F1ChiefMechanicEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ForMember(dest => dest.Morale, opt => opt.ResolveUsing(src => valueConverterService.ConvertToOneToFiveStepOne(src.Morale)))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.Morale, opt => opt.ResolveUsing(dest => valueConverterService.ConvertToTwentyToHundredStepTwenty(dest.Morale)));

            CreateMap<F1DriverDataEntity, F1DriverEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id / 3 + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ForMember(dest => dest.Morale, opt => opt.ResolveUsing(src => valueConverterService.ConvertToOneToFiveStepOne(src.Morale)))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.Morale, opt => opt.ResolveUsing(dest => valueConverterService.ConvertToTwentyToHundredStepTwenty(dest.Morale)));
        }
    }
}