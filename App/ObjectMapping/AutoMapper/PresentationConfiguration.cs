using System;
using System.Collections.Generic;
using App.BaseGameEditor.Presentation.Maps.AutoMapper;
using AutoMapper;

namespace App.ObjectMapping.AutoMapper
{
    public class PresentationConfiguration : IAutoMapperConfiguration
    {
        private readonly IEnumerable<IAutoMapperPresentationProfile> _autoMapperProfiles;

        public PresentationConfiguration(IEnumerable<IAutoMapperPresentationProfile> autoMapperProfiles)
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