using Common.Editor.Domain.Models;

namespace App.BaseGameEditor.Infrastructure.Mappers
{
    public interface IDataContextToModelMapper<out T>
        where T : class, IModel
    {
        T Map(int id);
    }
}