// TODO: Remove?
//using System;
//using System.Collections.Generic;
//using App.BaseGameEditor.Infrastructure.Services;
//using App.ObjectMapping.AutoMapper;
//using AutoMapper;

//namespace App.Services
//{
//    public class AutoMapperObjectMapperService : IMapperService
//    {
//        private readonly IEnumerable<IAutoMapperConfiguration> _autoMapperConfigurations;
//        private IMapper _mapper;

//        public AutoMapperObjectMapperService(IEnumerable<IAutoMapperConfiguration> autoMapperConfigurations)
//        {
//            _autoMapperConfigurations = autoMapperConfigurations ?? throw new ArgumentNullException(nameof(autoMapperConfigurations));
//        }

//        public void Initialise()
//        {
//            var mapperConfiguration = new MapperConfiguration(configure =>
//            {
//                // Invoke register mappings for every configuration class that implements IAutoMapperConfiguration
//                foreach (var item in _autoMapperConfigurations)
//                {
//                    item.RegisterMappings(configure);
//                }
//            });

//            mapperConfiguration.AssertConfigurationIsValid();
//            _mapper = mapperConfiguration.CreateMapper();
//        }

//        public TDestination Map<TSource, TDestination>(TSource source)
//        {
//            if (source == null) throw new ArgumentNullException(nameof(source));

//            return _mapper.Map<TDestination>(source);
//        }

//        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
//        {
//            if (source == null) throw new ArgumentNullException(nameof(source));
//            if (destination == null) throw new ArgumentNullException(nameof(destination));

//            return _mapper.Map(source, destination);
//        }
//    }
//}