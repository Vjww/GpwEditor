using App.BaseGameEditor.Infrastructure.Maps;
using AutoMapper;

namespace App.BaseGameEditor.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            // TODO: Redundant? As there are classes that perform the aggregation/parting instead
            mapperConfigurationExpression.AddProfile<TeamEntityOnTeamEntityMap>();
        }
    }
}