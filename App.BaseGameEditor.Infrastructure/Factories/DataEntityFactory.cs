using System;
using App.BaseGameEditor.Data.DataEntities;
using App.BaseGameEditor.Data.Factories;

namespace App.BaseGameEditor.Infrastructure.Factories
{
    public class DataEntityFactory<TDataEntity> : IDataEntityFactory<TDataEntity>
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