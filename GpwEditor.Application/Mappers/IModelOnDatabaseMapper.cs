using GpwEditor.Domain.Objects;
using GpwEditor.Infrastructure.Connections;
using GpwEditor.Infrastructure.Databases;
using GpwEditor.Infrastructure.DataSources;

namespace GpwEditor.Application.Mappers
{
    public interface IModelOnDatabaseMapper<in TModel, in TDatabase>
        where TModel : class, IObject
        where TDatabase : class, IDatabase<IDataSource<IConnection>, IConnection>
    {
        void Map(TDatabase from, TModel to);
        void Map(TModel from, TDatabase to);
    }
}