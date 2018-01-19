using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Entities;
using App.BaseGameEditor.Infrastructure.Factories;

namespace App.BaseGameEditor.Infrastructure.Maps
{
    public class CarNumberEntitiesToCarNumbersObjectMapper
    {
        private readonly CarNumbersObjectFactory _factory;

        public CarNumberEntitiesToCarNumbersObjectMapper(CarNumbersObjectFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public CarNumbersObject Map(IEnumerable<CarNumberEntity> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var list = items as IList<CarNumberEntity> ?? items.ToList();
            if (list.Count != 2) throw new ArgumentOutOfRangeException();

            var carNumbersObject = _factory.Create();
            carNumbersObject.CarNumberDriver1 = list.Single(x => x.PositionId == 0).ValueA;
            carNumbersObject.CarNumberDriver2 = list.Single(x => x.PositionId == 1).ValueA;
            return carNumbersObject;
        }
    }
}