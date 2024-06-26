﻿using App.BaseGameEditor.Application.Maps.AutoMapper.MemberValueResolvers;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Domain.Entities;
using AutoMapper;

namespace App.BaseGameEditor.Application.Maps.AutoMapper
{
    public class PersonDataEntityOnPersonEntityProfile : Profile
    {
        public PersonDataEntityOnPersonEntityProfile()
        {
            CreateMap<F1ChiefCommercialDataEntity, F1ChiefCommercialEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ForMember(dest => dest.Morale, opt => opt.ResolveUsing<EntityMoraleMemberValueResolver, int>(src => src.Morale))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.Morale, opt => opt.ResolveUsing<DataEntityMoraleMemberValueResolver, int>(dest => dest.Morale));

            CreateMap<F1ChiefDesignerDataEntity, F1ChiefDesignerEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ForMember(dest => dest.Morale, opt => opt.ResolveUsing<EntityMoraleMemberValueResolver, int>(src => src.Morale))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.Morale, opt => opt.ResolveUsing<DataEntityMoraleMemberValueResolver, int>(dest => dest.Morale));

            CreateMap<F1ChiefEngineerDataEntity, F1ChiefEngineerEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ForMember(dest => dest.Morale, opt => opt.ResolveUsing<EntityMoraleMemberValueResolver, int>(src => src.Morale))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.Morale, opt => opt.ResolveUsing<DataEntityMoraleMemberValueResolver, int>(dest => dest.Morale));

            CreateMap<F1ChiefMechanicDataEntity, F1ChiefMechanicEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ForMember(dest => dest.Morale, opt => opt.ResolveUsing<EntityMoraleMemberValueResolver, int>(src => src.Morale))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.Morale, opt => opt.ResolveUsing<DataEntityMoraleMemberValueResolver, int>(dest => dest.Morale));

            CreateMap<F1DriverDataEntity, F1DriverEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TeamId, opt => opt.ResolveUsing(src => src.Id / 3 + 1))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ForMember(dest => dest.Morale, opt => opt.ResolveUsing<EntityMoraleMemberValueResolver, int>(src => src.Morale))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name))
                .ForMember(src => src.PayRating, opt => opt.ResolveUsing<DataEntityF1DriverPayRatingMemberValueResolver, int>(dest => dest.Salary))
                .ForMember(src => src.PositiveSalary, opt => opt.ResolveUsing<DataEntityF1DriverPositiveSalaryMemberValueResolver, int>(dest => dest.Salary))
                .ForMember(src => src.Morale, opt => opt.ResolveUsing<DataEntityMoraleMemberValueResolver, int>(dest => dest.Morale));

            CreateMap<NonF1ChiefCommercialDataEntity, NonF1ChiefCommercialEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));

            CreateMap<NonF1ChiefDesignerDataEntity, NonF1ChiefDesignerEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));

            CreateMap<NonF1ChiefEngineerDataEntity, NonF1ChiefEngineerEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));

            CreateMap<NonF1ChiefMechanicDataEntity, NonF1ChiefMechanicEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));

            CreateMap<NonF1DriverDataEntity, NonF1DriverEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Shared))
                // Morale for a Non-F1 driver does not require a transformation, as game initialisation code will self-convert values (e.g. 2 -> 40, 5 -> 100)
                .ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore())
                .ForPath(src => src.Name.Shared, opt => opt.MapFrom(dest => dest.Name));
                // Morale for a Non-F1 driver does not require a transformation, as game initialisation code will self-convert values (e.g. 2 -> 40, 5 -> 100)
        }
    }
}
