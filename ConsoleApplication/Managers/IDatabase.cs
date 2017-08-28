using ConsoleApplication.DataSources;
using ConsoleApplication.Infrastructure;

namespace ConsoleApplication.Managers
{
    public interface IDatabase<in T, TU>
        where T : class, IDataSource<TU>
        where TU : class, IConnectionStrings
    {
        void Import(T dataSource);
        void Export(T dataSource);
    }
}