using AutoMapper;
using GpwEditor.Application.Maps;

namespace GpwEditor.Application
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<TeamEntityOnTeamModelMap>();
            });
        }
    }
}