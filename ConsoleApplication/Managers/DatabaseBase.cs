using System.Collections.ObjectModel;
using ConsoleApplication.DataSources;
using ConsoleApplication.Entities;
using ConsoleApplication.Infrastructure;
using ConsoleApplication.Mappers;
using ConsoleApplication.Populators;
using ConsoleApplication.Repositories;

namespace ConsoleApplication.Managers
{
    public abstract class DatabaseBase<T, TU> : IDatabase<T, TU>
        where T : class, IDataSource<TU>
        where TU : class, IConnectionStrings
    {
        public abstract void Import(T dataSource);

        public abstract void Export(T dataSource);

        protected static Repository<TEntity> ImportRepositoryFromDataSource<TDataSource, TEntity, TMapper, TPopulator>(TDataSource dataSource, int itemCount)
            where TEntity : class, IEntity, new()
            where TMapper : class, IMapper, new()
            where TPopulator : class, IPopulator<TDataSource, TEntity, TMapper>, new()
        {
            var collection = new Collection<TEntity>();
            for (var i = 0; i < itemCount; i++)
            {
                var entity = new TEntity { Id = i };
                var mapper = new TMapper { Id = i };
                mapper.Map();

                var populator = new TPopulator();
                populator.ImportEntityFromDataSource(dataSource, entity, mapper);

                collection.Add(entity);
            }
            return new Repository<TEntity>(collection);
        }

        protected static void ExportDataSourceFromRepository<TDataSource, TEntity, TMapper, TPopulator>(TDataSource dataSource, IRepository<TEntity> repository, int itemCount)
            where TEntity : class, IEntity
            where TMapper : class, IMapper, new()
            where TPopulator : class, IPopulator<TDataSource, TEntity, TMapper>, new()
        {
            for (var i = 0; i < itemCount; i++)
            {
                var entity = repository.GetById(i);

                var mapper = new TMapper { Id = i };
                mapper.Map();

                var populator = new TPopulator();
                populator.ExportEntityToDataSource(dataSource, entity, mapper);
            }
        }
    }
}