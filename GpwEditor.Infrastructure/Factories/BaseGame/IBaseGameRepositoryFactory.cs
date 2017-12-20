using Common.Editor.Data.Entities;
using GpwEditor.Infrastructure.Repositories.BaseGame;

namespace GpwEditor.Infrastructure.Factories.BaseGame
{
    public interface IBaseGameRepositoryFactory
    {
        IBaseGameRepository<IEntity> Create(BaseGameRepositoryEnum repositoryType);
    }
}