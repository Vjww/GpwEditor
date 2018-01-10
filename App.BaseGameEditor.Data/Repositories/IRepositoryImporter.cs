using System.Collections.Generic;
using App.BaseGameEditor.Data.Entities;

namespace App.BaseGameEditor.Data.Repositories
{
    public interface IRepositoryImporter
    {
        IEnumerable<IEntity> Import(int repositoryCapacity);
    }
}