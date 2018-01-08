using App.BaseGameEditor.Presentation.Maps;
using AutoMapper;

namespace App.BaseGameEditor.Presentation.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.AddProfile<TeamModelOnTeamViewModelMap>();
        }
    }
}