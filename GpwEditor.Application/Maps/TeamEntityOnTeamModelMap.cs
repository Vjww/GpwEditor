using AutoMapper;
using GpwEditor.Domain.Models.BaseGame;
using GpwEditor.Infrastructure.Entities.BaseGame;

namespace GpwEditor.Application.Maps
{
    public class TeamEntityOnTeamModelMap
    {
        public static void Initialize(IMapperConfigurationExpression config)
        {
            config.CreateMap<TeamEntity, ITeamModel>();
            config.CreateMap<ITeamModel, TeamEntity>();

            /*
            config.CreateMap<File, AddFileDto>()
                //.ForMember(t => t.ColId, opt => opt.MapFrom(s => s.CommunityId))
                .ForMember(t => t.ContentType, opt => opt.MapFrom(s => s.ContentType))
                .ForMember(t => t.FileType, opt => opt.MapFrom(s => s.FileType))
                .ForMember(t => t.FileName, opt => opt.MapFrom(s => s.FileName))
                .ForMember(t => t.Content, opt => opt.MapFrom(s => s.Content))
                ;
                 */
        }
    }
}