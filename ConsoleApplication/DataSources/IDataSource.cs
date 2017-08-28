using ConsoleApplication.Infrastructure;

namespace ConsoleApplication.DataSources
{
    public interface IDataSource<in T>
        where T : class, IConnectionStrings
    {
        void Load(T connectionStrings);
        void Save(T connectionStrings);
    }
}