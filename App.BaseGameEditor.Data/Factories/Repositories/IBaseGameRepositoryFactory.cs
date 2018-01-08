using App.BaseGameEditor.Data.Enums;
using App.BaseGameEditor.Data.Repositories.BaseGame;

namespace App.BaseGameEditor.Data.Factories.Repositories
{
    public interface IBaseGameRepositoryFactory
    {
        IBaseGameRepository Create(BaseGameRepositoryType repository);
    }
}