using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public interface IModelToDataContextMapper<in T>
        where T : class, IEntity
    {
        void Map(T model);
    }
}