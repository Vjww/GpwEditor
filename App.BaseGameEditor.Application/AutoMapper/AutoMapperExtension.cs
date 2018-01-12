using AutoMapper;

namespace App.BaseGameEditor.Application.AutoMapper
{
    public static class AutoMapperExtension
    {
        public static TDestination Map<TSource, TDestination>(
            this TDestination destination, TSource source)
        {
            return Mapper.Map(source, destination);
        }
    }
}