using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.DataSources;

namespace GpwEditor.Infrastructure.Databases
{
    public interface IDatabase<in T, TU>
        where T : class, IDataSource<TU>
        where TU : class, IConnectionStrings
    {
        void Import(T dataSource);
        void Export(T dataSource);
    }
}