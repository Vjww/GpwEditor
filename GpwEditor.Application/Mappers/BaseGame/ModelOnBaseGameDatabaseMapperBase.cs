using GpwEditor.Domain.Objects;
using GpwEditor.Infrastructure.Connections;
using GpwEditor.Infrastructure.Databases;
using GpwEditor.Infrastructure.DataSources;

namespace GpwEditor.Application.Mappers.BaseGame
{
    public abstract class ModelOnBaseGameDatabaseMapper<TModel, TDatabase> : IModelOnDatabaseMapper<TModel, DatabaseBase<BaseGameDataContext, BaseGameConnection>>
        where TModel : class, IObject
        where TDatabase : class, DatabaseBase<BaseGameDataContext, BaseGameConnection>
    {
        protected abstract void Map(TDatabase from, TModel to);
        protected abstract void Map(TModel from, TDatabase to);
    }
}