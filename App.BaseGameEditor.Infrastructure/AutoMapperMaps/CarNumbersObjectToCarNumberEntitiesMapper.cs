using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Data.Factories;
using TeamEntity = App.BaseGameEditor.Domain.Entities.TeamEntity;

namespace App.BaseGameEditor.Infrastructure.AutoMapperMaps
{
    public class CarNumbersObjectToCarNumberEntitiesMapper
    {
        private readonly CarNumberEntityFactory _factory;

        public CarNumbersObjectToCarNumberEntitiesMapper(CarNumberEntityFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IEnumerable<CarNumberEntity> Map(TeamEntity team)
        {
            var item1 = _factory.Create(team.Id * 2);
            item1.TeamId = team.Id;
            item1.PositionId = 0;
            item1.ValueA = team.CarNumberDriver1;
            item1.ValueB = team.CarNumberDriver1;

            var item2 = _factory.Create(team.Id * 2 + 1);
            item1.TeamId = team.Id;
            item1.PositionId = 1;
            item1.ValueA = team.CarNumberDriver2;
            item1.ValueB = team.CarNumberDriver2;

            return new List<CarNumberEntity> { item1, item2 };
        }
    }
}