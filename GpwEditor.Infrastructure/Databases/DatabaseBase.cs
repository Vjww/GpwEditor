using System.Collections.Generic;
using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.DataSources;
using GpwEditor.Infrastructure.Entities;
using GpwEditor.Infrastructure.Factories;
using GpwEditor.Infrastructure.Mappers;
using GpwEditor.Infrastructure.Populators;
using GpwEditor.Infrastructure.Repositories;

namespace GpwEditor.Infrastructure.Databases
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
            var list = new List<TEntity>();
            for (var i = 0; i < itemCount; i++)
            {
                var entity = EntityFactory<TEntity>.New(i);
                var mapper = MapperFactory<TMapper>.New(i);
                mapper.Map();

                var populator = new TPopulator();
                populator.ImportEntityFromDataSource(dataSource, entity, mapper);

                list.Add(entity);
            }
            return new Repository<TEntity>(list);
        }

        protected static void ExportDataSourceFromRepository<TDataSource, TEntity, TMapper, TPopulator>(TDataSource dataSource, IRepository<TEntity> repository, int itemCount)
            where TEntity : class, IEntity
            where TMapper : class, IMapper, new()
            where TPopulator : class, IPopulator<TDataSource, TEntity, TMapper>, new()
        {
            for (var i = 0; i < itemCount; i++)
            {
                var entity = repository.GetById(i);
                var mapper = MapperFactory<TMapper>.New(i);
                mapper.Map();

                var populator = new TPopulator();
                populator.ExportEntityToDataSource(dataSource, entity, mapper);
            }
        }
    }
}