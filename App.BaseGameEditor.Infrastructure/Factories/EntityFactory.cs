using System;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Factories
{
    public class EntityFactory<TEntity>
        where TEntity : class, IEntity
    {
        private readonly Func<TEntity> _instantiateType;

        public EntityFactory(Func<TEntity> instantiateType)
        {
            _instantiateType = instantiateType ?? throw new ArgumentNullException(nameof(instantiateType));
        }

        public TEntity Create(int id)
        {
            var result = _instantiateType.Invoke();
            result.Id = id;
            return result;
        }
    }
}