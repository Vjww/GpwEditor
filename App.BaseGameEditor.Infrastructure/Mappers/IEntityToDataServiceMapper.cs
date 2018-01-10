using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public interface IEntityToDataServiceMapper<in TEntity>
        where TEntity : class, IEntity
    {
        void Map(TEntity entity);
    }
}