using System;
using App.BaseGameEditor.Infrastructure.Services;
using App.ObjectMapping.AutoMapper.Configurations;
using AutoMapper;

namespace App.Services
{
    public class AutoMapperObjectMapperService : IMapperService
    {
        private readonly PresentationConfiguration _presentationConfiguration;
        private readonly InfrastructureConfiguration _infrastructureConfiguration;
        private IMapper _mapper;

        public AutoMapperObjectMapperService(
            PresentationConfiguration presentationConfiguration,
            InfrastructureConfiguration infrastructureConfiguration)
        {
            _presentationConfiguration = presentationConfiguration ?? throw new ArgumentNullException(nameof(presentationConfiguration));
            _infrastructureConfiguration = infrastructureConfiguration ?? throw new ArgumentNullException(nameof(infrastructureConfiguration));
        }

        public void Initialise()
        {
            // TODO: Could MapperConfiguration be injected with parameter somehow?
            var mapperConfiguration = new MapperConfiguration(configure =>
            {
                _presentationConfiguration.RegisterMappings(configure);
                _infrastructureConfiguration.RegisterMappings(configure);
            });
            mapperConfiguration.AssertConfigurationIsValid();
            _mapper = mapperConfiguration.CreateMapper();
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (destination == null) throw new ArgumentNullException(nameof(destination));

            return _mapper.Map(source, destination);
        }
    }
}