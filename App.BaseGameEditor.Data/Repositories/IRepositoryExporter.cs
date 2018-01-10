using System.Collections.Generic;
using App.BaseGameEditor.Data.Entities;

namespace App.BaseGameEditor.Data.Repositories
{
    public interface IRepositoryExporter
    {
        void Export(IEnumerable<IEntity> entities);
    }
}