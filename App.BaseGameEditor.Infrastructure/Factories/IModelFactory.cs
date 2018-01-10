using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Factories
{
    public interface IModelFactory<out TModel>
        where TModel : class, IEntity
    {
        TModel Create(int id);
    }
}