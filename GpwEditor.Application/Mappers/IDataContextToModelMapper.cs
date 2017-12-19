using GpwEditor.Domain.Models;

namespace GpwEditor.Application.Mappers
{
    public interface IDataContextToModelMapper<out T>
        where T : class, IModel
    {
        T Map(int id);
    }
}