using System;
using App.ObjectMapping.AutoMapper.Profiles;
using AutoMapper;

namespace App.ObjectMapping.AutoMapper.Configurations
{
    public class PresentationConfiguration
    {
        public void RegisterMappings(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            if (mapperConfigurationExpression == null)
                throw new ArgumentNullException(nameof(mapperConfigurationExpression));

            mapperConfigurationExpression.AddProfile<TeamEntityOnTeamViewModelProfile>();
        }
    }
}