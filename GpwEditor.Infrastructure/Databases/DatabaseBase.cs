using System.Collections.Generic;
using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.DataSources;
using GpwEditor.Infrastructure.Entities;
using GpwEditor.Infrastructure.Factories;
using GpwEditor.Infrastructure.Populators;
using GpwEditor.Infrastructure.Repositories;
using GpwEditor.Infrastructure.ValueMappers;

namespace GpwEditor.Infrastructure.Databases
{
    public abstract class DatabaseBase<T, TU> : IDatabase<T, TU>
        where T : class, IDataSource<TU>
        where TU : class, IConnectionStrings
    {
        public abstract void Import(T dataSource);

        public abstract void Export(T dataSource);

        protected static Repository<TEntity> ImportRepositoryFromDataSource<TDataSource, TEntity, TValueMapper, TPopulator>(TDataSource dataSource, int itemCount)
            where TEntity : class, IEntity, new()
            where TValueMapper : class, IValueMapper, new()
            where TPopulator : class, IPopulator<TDataSource, TEntity, TValueMapper>, new()
        {
            var list = new List<TEntity>();
            for (var i = 0; i < itemCount; i++)
            {
                var entity = EntityFactory<TEntity>.New(i);
                var mapper = ValueMapperFactory<TValueMapper>.New(i);
                mapper.Map();

                var populator = new TPopulator();
                populator.ImportEntityFromDataSource(dataSource, entity, mapper);

                list.Add(entity);
            }
            return new Repository<TEntity>(list);
        }

        protected static void ExportDataSourceFromRepository<TDataSource, TEntity, TValueMapper, TPopulator>(TDataSource dataSource, IRepository<TEntity> repository, int itemCount)
            where TEntity : class, IEntity
            where TValueMapper : class, IValueMapper, new()
            where TPopulator : class, IPopulator<TDataSource, TEntity, TValueMapper>, new()
        {
            for (var i = 0; i < itemCount; i++)
            {
                var entity = repository.GetById(i);
                var mapper = ValueMapperFactory<TValueMapper>.New(i);
                mapper.Map();

                var populator = new TPopulator();
                populator.ExportEntityToDataSource(dataSource, entity, mapper);
            }
        }
    }
}