using System.Collections.Generic;
using App.BaseGameEditor.Data.Entities;
using TeamEntity = App.BaseGameEditor.Domain.Entities.TeamEntity;

namespace App.BaseGameEditor.Infrastructure.AutoMapperMaps
{
    public class CarNumbersObjectToCarNumberEntitiesMapper
    {
        public IEnumerable<CarNumberEntity> Map(TeamEntity team)
        {
            var list = new List<CarNumberEntity>
            {
                new CarNumberEntity // TODO: should new up via factory?
                {
                    Id = team.Id * 2,
                    TeamId = team.TeamId,
                    PositionId = 0,
                    ValueA = team.CarNumberDriver1,
                    ValueB = team.CarNumberDriver1
                },
                new CarNumberEntity // TODO: should new up via factory?
                {
                    Id = team.Id * 2 + 1,
                    TeamId = team.TeamId,
                    PositionId = 1,
                    ValueA = team.CarNumberDriver2,
                    ValueB = team.CarNumberDriver2
                }
            };
            return list;
        }
    }
}