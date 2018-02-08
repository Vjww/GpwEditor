using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;
using App.Core.Factories;
using App.ObjectMapping.Objects;

namespace App.ObjectMapping.Maps.Manual
{
    public class CarNumbersObjectToCarNumberDataEntitiesMapper
    {
        private readonly IIntegerIdentityFactory<CarNumberDataEntity> _factory;

        public CarNumbersObjectToCarNumberDataEntitiesMapper(IIntegerIdentityFactory<CarNumberDataEntity> factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public IEnumerable<CarNumberDataEntity> Map(CarNumbersObject item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            var resultItem1 = _factory.Create(item.Id * 2);
            resultItem1.TeamId = item.Id;
            resultItem1.PositionId = 0;
            resultItem1.ValueA = item.CarNumberDriver1;
            resultItem1.ValueB = item.CarNumberDriver1;

            var resultItem2 = _factory.Create(item.Id * 2 + 1);
            resultItem2.TeamId = item.Id;
            resultItem2.PositionId = 1;
            resultItem2.ValueA = item.CarNumberDriver2;
            resultItem2.ValueB = item.CarNumberDriver2;

            return new List<CarNumberDataEntity> { resultItem1, resultItem2 };
        }
    }
}