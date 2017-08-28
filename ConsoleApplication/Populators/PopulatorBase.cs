﻿using System;
using System.IO;
using ConsoleApplication.DataSources;
using ConsoleApplication.Entities;
using ConsoleApplication.Infrastructure;
using ConsoleApplication.Mappers;
using ConsoleApplication.Services;

namespace ConsoleApplication.Populators
{
    public abstract class PopulatorBase<T, TU, TV, TW> : IPopulator<T, TV, TW>
        where T : class, IDataSource<TU>
        where TU : class, IConnectionStrings
        where TV : class, IEntity
        where TW : class, IMapper
    {
        public abstract void ImportEntityFromDataSource(T dataSource, TV entity, TW mapper);

        public abstract void ExportEntityToDataSource(T dataSource, TV entity, TW mapper);

        protected int ReadIntegerFromMemoryStream(IStreamService<MemoryStream> memoryStream, int offset)
        {
            var bytes = memoryStream.Read(offset, 4);
            return BitConverter.ToInt32(bytes, 0);
        }

        protected void WriteIntegerToMemoryStream(IStreamService<MemoryStream> memoryStream, int offset, int value)
        {
            var bytes = BitConverter.GetBytes(value);
            memoryStream.Write(offset, bytes);
        }
    }
}