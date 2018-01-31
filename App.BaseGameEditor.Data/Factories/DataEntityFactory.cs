using System;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Factories
{
    public class DataEntityFactory<TDataEntity>
        where TDataEntity : class, IDataEntity
    {
        private readonly Func<TDataEntity> _instantiateType;

        public DataEntityFactory(Func<TDataEntity> instantiateType)
        {
            _instantiateType = instantiateType ?? throw new ArgumentNullException(nameof(instantiateType));
        }

        public TDataEntity Create(int id)
        {
            var result = _instantiateType.Invoke();
            result.Id = id;
            return result;
        }
    }
}