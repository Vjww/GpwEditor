using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public abstract class RepositoryExporterBase : IRepositoryExporter
    {
        private readonly IDataEntityExporter _dataEntityExporter;

        protected RepositoryExporterBase(IDataEntityExporter dataEntityExporter)
        {
            _dataEntityExporter = dataEntityExporter ?? throw new ArgumentNullException(nameof(dataEntityExporter));
        }

        public void Export(IEnumerable<IDataEntity> items)
        {
            foreach (var item in items)
            {
                _dataEntityExporter.Export(item);
            }
        }
    }
}