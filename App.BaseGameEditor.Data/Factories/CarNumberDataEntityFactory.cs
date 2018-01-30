using System;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Factories
{
    public class CarNumberDataEntityFactory
    {
        private readonly Func<CarNumberDataEntity> _instantiateType;

        public CarNumberDataEntityFactory(Func<CarNumberDataEntity> instantiateType)
        {
            _instantiateType = instantiateType ?? throw new ArgumentNullException(nameof(instantiateType));
        }

        public CarNumberDataEntity Create(int id)
        {
            var result = _instantiateType.Invoke();
            result.Id = id;
            return result;
        }
    }
}