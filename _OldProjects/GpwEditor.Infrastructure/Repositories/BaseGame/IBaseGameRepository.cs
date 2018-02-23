using Common.Editor.Data.Repositories;
using GpwEditor.Infrastructure.Enums;

namespace GpwEditor.Infrastructure.Repositories.BaseGame
{
    public interface IBaseGameRepository : IRepository
    {
        BaseGameRepositoryType Type { get; }
    }
}