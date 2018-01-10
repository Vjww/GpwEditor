using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public interface IDataContextToEntityMapper<out TEntity>
        where TEntity : class, IEntity
    {
        TEntity Map(int id);
    }
}