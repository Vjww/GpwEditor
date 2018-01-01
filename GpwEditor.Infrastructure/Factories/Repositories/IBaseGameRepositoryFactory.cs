using GpwEditor.Infrastructure.Enums;
using GpwEditor.Infrastructure.Repositories.BaseGame;

namespace GpwEditor.Infrastructure.Factories.Repositories
{
    public interface IBaseGameRepositoryFactory
    {
        IBaseGameRepository Create(BaseGameRepositoryType repository);
    }
}