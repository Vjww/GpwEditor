using System;
using System.Collections.Generic;
using System.Linq;
using App.BaseGameEditor.Data.Entities;

namespace App.BaseGameEditor.Infrastructure.AutoMapperMaps
{
    public class CarNumberEntitiesToCarNumbersObjectMapper
    {
        public CarNumbersObject Map(IEnumerable<CarNumberEntity> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var list = items as IList<CarNumberEntity> ?? items.ToList();
            if (list.Count != 2) throw new ArgumentOutOfRangeException();
            return new CarNumbersObject // TODO: should new up via factory?
            {
                CarNumberDriver1 = list.Single(x => x.PositionId == 0).ValueA,
                CarNumberDriver2 = list.Single(x => x.PositionId == 1).ValueA
            };
        }
    }
}