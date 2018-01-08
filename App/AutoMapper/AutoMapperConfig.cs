using AutoMapper;
using PresentationAutoMapper = App.BaseGameEditor.Presentation.AutoMapper;
using ApplicationAutoMapper = App.BaseGameEditor.Application.AutoMapper;

namespace App.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(mapperConfigurationExpression =>
            {
                PresentationAutoMapper.AutoMapperConfig.RegisterMappings(mapperConfigurationExpression);
                ApplicationAutoMapper.AutoMapperConfig.RegisterMappings(mapperConfigurationExpression);
            });
        }
    }
}