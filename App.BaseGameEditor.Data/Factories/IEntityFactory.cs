using App.BaseGameEditor.Data.Entities;

namespace App.BaseGameEditor.Data.Factories
{
    public interface IEntityFactory<out TEntity>
        where TEntity : class, IEntity
    {
        TEntity Create(int id);
    }
}