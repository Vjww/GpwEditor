using AutoMapper;

namespace App.ObjectMapping.AutoMapper
{
    public interface IAutoMapperConfiguration
    {
        void RegisterMappings(IMapperConfigurationExpression mapperConfigurationExpression);
    }
}