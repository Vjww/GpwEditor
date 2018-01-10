using App.BaseGameEditor.Data.Enums;

namespace App.BaseGameEditor.Data.Repositories
{
    public interface IBaseGameRepository : IRepository
    {
        BaseGameRepositoryType Type { get; }
    }
}