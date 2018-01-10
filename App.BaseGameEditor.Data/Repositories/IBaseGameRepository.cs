using App.BaseGameEditor.Data.Enums;
using Common.Editor.Data.Repositories;

namespace App.BaseGameEditor.Data.Repositories
{
    public interface IBaseGameRepository : IRepository
    {
        BaseGameRepositoryType Type { get; }
    }
}