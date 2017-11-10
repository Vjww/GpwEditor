using GpwEditor.Infrastructure.Connections;
using GpwEditor.Infrastructure.Databases;
using GpwEditor.Infrastructure.DataSources;

namespace GpwEditor.Application.Models
{
    public abstract class ModelBase<T, TU, TV>
        where T : class, IDatabase<TU, TV>
        where TU : class, IDataSource<TV>
        where TV : class, IConnection
    {
        protected readonly T Database;
        public readonly int Id;

        protected ModelBase(T database, int id)
        {
            Database = database;
            Id = id;
        }

        public abstract void Get();

        public abstract void Set();
    }
}