using App.Core.Entities;

namespace App.Core.Factories
{
    public interface IEntityFactory<out TEntity>
        where TEntity : class, IEntity
    {
        TEntity Create(int id);
    }
}