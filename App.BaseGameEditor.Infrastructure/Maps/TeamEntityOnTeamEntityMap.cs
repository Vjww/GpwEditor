using AutoMapper;
namespace App.BaseGameEditor.Infrastructure.Maps
{
    // TODO: Redundant? As there are classes that perform the aggregation/parting instead
    // TODO: Maybe able to use AutoMapper to perform aggregation/parting?
    // TODO: https://lostechies.com/jimmybogard/2014/04/08/using-automapper-to-perform-linq-aggregations/
    public class TeamEntityOnTeamEntityMap : Profile
    {
        public TeamEntityOnTeamEntityMap()
        {
            CreateMap<Data.Entities.TeamEntity, Domain.Entities.TeamEntity>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.All))
                .ReverseMap()
                .ForPath(src => src.Name.All, opt => opt.MapFrom(dest => dest.Name));
        }
    }
}