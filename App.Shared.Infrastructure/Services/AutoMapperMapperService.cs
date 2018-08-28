using System;
using AutoMapper;

namespace App.Shared.Infrastructure.Services
{
    public class AutoMapperMapperService : IMapperService
    {
        private readonly IMapper _mapper;

        public AutoMapperMapperService(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
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