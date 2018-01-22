using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public interface IRepositoryImporter
    {
        IEnumerable<IDataEntity> Import(int repositoryCapacity);
    }
}