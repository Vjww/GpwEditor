using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public interface IEntityToDataContextMapper<in TEntity>
        where TEntity : class, IEntity
    {
        void Map(TEntity entity);
    }
}