﻿using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Infrastructure.Factories;
using App.BaseGameEditor.Infrastructure.Objects;

namespace App.BaseGameEditor.Application.Maps.Manual
{
    public class CarNumberDataEntitiesToCarNumbersObjectMapper
    {
        private readonly CarNumbersObjectFactory _factory;

        public CarNumberDataEntitiesToCarNumbersObjectMapper(CarNumbersObjectFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public CarNumbersObject Map(IEnumerable<CarNumberDataEntity> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var list = items as IList<CarNumberDataEntity> ?? items.ToList();
            if (list.Count != 2) throw new ArgumentOutOfRangeException();

            var result = _factory.Create(list.Single(x => x.PositionId == 0).Id / 2);
            result.CarNumberDriver1 = list.Single(x => x.PositionId == 0).ValueA;
            result.CarNumberDriver2 = list.Single(x => x.PositionId == 1).ValueA;
            return result;
        }
    }
}