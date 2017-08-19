using System;
using ConsoleApplication.DataSources;
using ConsoleApplication.Entities;
using ConsoleApplication.Mappers;
using ConsoleApplication.Services;

namespace ConsoleApplication.Populators
{
    public abstract class PopulatorBase<T, TU> : IPopulator<T, TU>
        where T : class, IEntity
        where TU : class, IMapper
    {
        public abstract void PopulateEntityFromDataSource(IDataSource dataSource, T entity, TU mapper);

        public abstract void PopulateDataSourceFromEntity(IDataSource dataSource, T entity, TU mapper);

        protected int ReadIntegerFromMemoryStream(IMemoryStreamService memoryStream, int offset)
        {
            var bytes = memoryStream.Read(offset, 4);
            return BitConverter.ToInt32(bytes, 0);
        }

        protected void WriteIntegerToMemoryStream(IMemoryStreamService memoryStream, int offset, int value)
        {
            var bytes = BitConverter.GetBytes(value);
            memoryStream.Write(offset, bytes);
        }
    }
}