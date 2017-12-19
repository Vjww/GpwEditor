using GpwEditor.Domain.Models;

namespace GpwEditor.Application.Mappers
{
    public interface IModelToDataContextMapper<in T>
        where T : class, IModel
    {
        void Map(T model);
    }
}