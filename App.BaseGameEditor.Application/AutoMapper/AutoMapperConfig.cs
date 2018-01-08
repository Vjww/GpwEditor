﻿using App.BaseGameEditor.Infrastructure.Maps;
using AutoMapper;

namespace App.BaseGameEditor.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings(IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.AddProfile<TeamEntityOnTeamModelMap>();
        }
    }
}