using Common.Editor.Data.Entities;
using Common.Editor.Data.Repositories;

namespace GpwEditor.Infrastructure.Repositories.BaseGame
{
    public interface IBaseGameRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        BaseGameRepositoryEnum RepositoryType { get; set; }
    }
}