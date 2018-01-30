using System;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Factories
{
    public class ChassisHandlingDataEntityFactory
    {
        private readonly Func<ChassisHandlingDataEntity> _instantiateType;

        public ChassisHandlingDataEntityFactory(Func<ChassisHandlingDataEntity> instantiateType)
        {
            _instantiateType = instantiateType ?? throw new ArgumentNullException(nameof(instantiateType));
        }

        public ChassisHandlingDataEntity Create(int id)
        {
            var result = _instantiateType.Invoke();
            result.Id = id;
            return result;
        }
    }
}