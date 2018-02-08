using System;
using App.ObjectMapping.Objects;

namespace App.ObjectMapping.Factories
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