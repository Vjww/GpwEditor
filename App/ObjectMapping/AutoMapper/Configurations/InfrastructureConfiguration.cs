using System;
using App.ObjectMapping.AutoMapper.Profiles;
using AutoMapper;

namespace App.ObjectMapping.AutoMapper.Configurations
{
    public class InfrastructureConfiguration
    {
        private readonly MultipleDataEntitiesOnTeamEntityProfile _multipleDataEntitiesOnTeamEntityProfile;
        private readonly PersonDataEntityOnPersonEntityProfile _personDataEntityOnPersonEntityProfile;

        public InfrastructureConfiguration(
            MultipleDataEntitiesOnTeamEntityProfile multipleDataEntitiesOnTeamEntityProfile,
            PersonDataEntityOnPersonEntityProfile personDataEntityOnPersonEntityProfile)
        {
            _multipleDataEntitiesOnTeamEntityProfile = multipleDataEntitiesOnTeamEntityProfile ?? throw new ArgumentNullException(nameof(multipleDataEntitiesOnTeamEntityProfile));
            _personDataEntityOnPersonEntityProfile = personDataEntityOnPersonEntityProfile ?? throw new ArgumentNullException(nameof(personDataEntityOnPersonEntityProfile));
        }

        public void RegisterMappings(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            if (mapperConfigurationExpression == null)
                throw new ArgumentNullException(nameof(mapperConfigurationExpression));

            // TODO: Consider using scanning for profiles or this alternative
            // TODO: https://www.jan-v.nl/post/using-dependency-injection-in-your-automapper-profile

            mapperConfigurationExpression.AddProfile(_multipleDataEntitiesOnTeamEntityProfile);
            mapperConfigurationExpression.AddProfile(_personDataEntityOnPersonEntityProfile);
        }
    }
}