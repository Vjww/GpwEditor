using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public interface IDataServiceToEntityMapper<out TEntity>
        where TEntity : class, IEntity
    {
        TEntity Map(int id);
    }
}