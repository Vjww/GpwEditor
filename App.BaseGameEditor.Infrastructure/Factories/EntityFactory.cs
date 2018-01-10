using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Factories
{
    public class EntityFactory<TEntity> : IEntityFactory<TEntity>
        where TEntity : class, IEntity, new()
    {
        public TEntity Create(int id)
        {
            // TODO: Should this be instantiated from a DI Container?
            // TODO: This factory class might need to reside under the composition root
            // TODO: if it is going to resolve from the DI Container, as the domain
            // TODO: should not reference the DI tool.
            // TODO: Alternatively a solution could be implemented by the DI Container.
            return new TEntity { Id = id };
        }
    }
}