using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Factories;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Maps
{
    public class CarNumbersObjectToCarNumberDataEntitiesMapper
    {
        private readonly CarNumberDataEntityFactory _factory;

        public CarNumbersObjectToCarNumberDataEntitiesMapper(CarNumberDataEntityFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IEnumerable<CarNumberDataEntity> Map(TeamEntity item)
        {
            // TODO: Shouldnt this method accept a CarNumbersObject?

            if (item == null) throw new ArgumentNullException(nameof(item));

            var resultItem1 = _factory.Create(item.Id * 2);
            resultItem1.TeamId = item.TeamId;
            resultItem1.PositionId = 0;
            resultItem1.ValueA = item.CarNumberDriver1;
            resultItem1.ValueB = item.CarNumberDriver1;

            var resultItem2 = _factory.Create(item.Id * 2 + 1);
            resultItem2.TeamId = item.TeamId;
            resultItem2.PositionId = 1;
            resultItem2.ValueA = item.CarNumberDriver2;
            resultItem2.ValueB = item.CarNumberDriver2;

            return new List<CarNumberDataEntity> { resultItem1, resultItem2 };
        }
    }
}