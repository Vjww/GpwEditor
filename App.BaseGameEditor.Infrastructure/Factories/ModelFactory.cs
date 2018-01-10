using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Factories
{
    public class ModelFactory<TModel> : IModelFactory<TModel>
        where TModel : class, IEntity, new()
    {
        public TModel Create(int id)
        {
            // TODO: Should this be instantiated from a DI Container?
            // TODO: This factory class might need to reside under the composition root
            // TODO: if it is going to resolve from the DI Container, as the domain
            // TODO: should not reference the DI tool
            return new TModel { Id = id };
        }
    }
}