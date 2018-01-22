using System.Collections.Generic;
using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Repositories
{
    public interface IRepositoryExporter
    {
        void Export(IEnumerable<IDataEntity> items);
    }
}