using Common.Editor.Domain.Models;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public interface IModelToDataContextMapper<in T>
        where T : class, IModel
    {
        void Map(T model);
    }
}