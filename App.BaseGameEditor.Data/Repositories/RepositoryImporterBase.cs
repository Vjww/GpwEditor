using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class RepositoryImporterBase : IRepositoryImporter
    {
        private readonly IDataEntityImporter _dataEntityImporter;

        protected RepositoryImporterBase(IDataEntityImporter dataEntityImporter)
        {
            _dataEntityImporter = dataEntityImporter ?? throw new ArgumentNullException(nameof(dataEntityImporter));
        }

        public IEnumerable<IDataEntity> Import(int repositoryCapacity)
        {
            if (repositoryCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(repositoryCapacity));
            }

            var result = new List<IDataEntity>();
            for (var i = 0; i < repositoryCapacity; i++)
            {
                var entity = _dataEntityImporter.Import(i);
                result.Add(entity);
            }

            return result;
        }
    }
}