using System;
using System.IO;
using GpwEditor.Infrastructure.ConnectionStrings;
using GpwEditor.Infrastructure.DataSources;
using GpwEditor.Infrastructure.Entities;
using GpwEditor.Infrastructure.Services;
using GpwEditor.Infrastructure.ValueMappers;

namespace GpwEditor.Infrastructure.Populators
{
    public abstract class PopulatorBase<T, TU, TV, TW> : IPopulator<T, TV, TW>
        where T : class, IDataSource<TU>
        where TU : class, IConnectionStrings
        where TV : class, IEntity
        where TW : class, IValueMapper
    {
        public abstract void ImportEntityFromDataSource(T dataSource, TV entity, TW valueMapper);

        public abstract void ExportEntityToDataSource(T dataSource, TV entity, TW valueMapper);

        protected int ReadIntegerFromMemoryStream(StreamService<MemoryStream> source, int offset)
        {
            var bytes = source.Read(offset, 4);
            return BitConverter.ToInt32(bytes, 0);
        }

        protected string ReadStringFromTextResource(ITextResourceService source, int id)
        {
            return source.Read(id);
        }

        protected void WriteIntegerToMemoryStream(StreamService<MemoryStream> source, int offset, int value)
        {
            var bytes = BitConverter.GetBytes(value);
            source.Write(offset, bytes);
        }

        protected void WriteStringToTextResource(ITextResourceService source, int id, string value)
        {
            source.Write(id, value);
        }
    }
}