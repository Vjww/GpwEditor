using GpwEditor.Domain.Models;

namespace GpwEditor.Application.Factories
{
    public interface IModelFactory<out TModel>
        where TModel : class, IModel
    {
        TModel Create(int id);
    }
}