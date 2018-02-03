using System;
using App.BaseGameEditor.Infrastructure.Maps.Manual;

namespace App.BaseGameEditor.Infrastructure.Factories
{
    public class CarNumbersObjectFactory
    {
        private readonly Func<CarNumbersObject> _instantiateType;

        public CarNumbersObjectFactory(Func<CarNumbersObject> instantiateType)
        {
            _instantiateType = instantiateType ?? throw new ArgumentNullException(nameof(instantiateType));
        }

        public CarNumbersObject Create(int id)
        {
            var result = _instantiateType.Invoke();
            result.Id = id;
            return result;
        }
    }
}