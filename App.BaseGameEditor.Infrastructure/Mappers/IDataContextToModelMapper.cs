using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public interface IDataContextToModelMapper<out T>
        where T : class, IEntity
    {
        T Map(int id);
    }
}