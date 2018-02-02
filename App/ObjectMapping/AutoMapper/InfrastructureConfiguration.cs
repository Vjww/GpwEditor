using System;
using System.Collections.Generic;
using App.BaseGameEditor.Infrastructure.Maps;
using AutoMapper;

namespace App.ObjectMapping.AutoMapper
{
    public class InfrastructureConfiguration : IAutoMapperConfiguration
    {
        private readonly IEnumerable<IAutoMapperInfrastructureProfile> _autoMapperProfiles;

        public InfrastructureConfiguration(IEnumerable<IAutoMapperInfrastructureProfile> autoMapperProfiles)
        {
            _autoMapperProfiles = autoMapperProfiles ?? throw new ArgumentNullException(nameof(autoMapperProfiles));
        }

        public void RegisterMappings(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            if (mapperConfigurationExpression == null)
                throw new ArgumentNullException(nameof(mapperConfigurationExpression));

            // Add every profile class that implements IAutoMapperProfile
            foreach (var item in _autoMapperProfiles)
            {
                mapperConfigurationExpression.AddProfile((Profile)item);
            }
        }
    }
}