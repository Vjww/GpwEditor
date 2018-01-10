using System;
using System.Collections.Generic;
using App.BaseGameEditor.Data.Entities;

namespace App.BaseGameEditor.Data.Repositories
{
    public class RepositoryImporterBase : IRepositoryImporter
    {
        private readonly IEntityImporter _entityImporter;

        protected RepositoryImporterBase(IEntityImporter entityImporter)
        {
            _entityImporter = entityImporter ?? throw new ArgumentNullException(nameof(entityImporter));
        }

        public IEnumerable<IEntity> Import(int repositoryCapacity)
        {
            if (repositoryCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(repositoryCapacity));
            }

            var entities = new List<IEntity>();
            for (var i = 0; i < repositoryCapacity; i++)
            {
                var entity = _entityImporter.Import(i);
                entities.Add(entity);
            }

            return entities;
        }
    }
}