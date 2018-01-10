using Common.Editor.Domain.Models;

namespace App.BaseGameEditor.Infrastructure.Factories
{
    public interface IModelFactory<out TModel>
        where TModel : class, IModel
    {
        TModel Create(int id);
    }
}