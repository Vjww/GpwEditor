using ConsoleApplication.DataSources;

namespace ConsoleApplication.Populators
{
    public interface IPopulator<in TEntity, in TMapper>
    {
        void PopulateEntityFromDataSource(IDataSource dataSource, TEntity entity, TMapper mapper);
        void PopulateDataSourceFromEntity(IDataSource dataSource, TEntity entity, TMapper mapper);
    }
}