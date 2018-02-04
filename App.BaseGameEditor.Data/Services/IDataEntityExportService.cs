using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Services
{
    public interface IDataEntityExportService<in TDataEntity>
        where TDataEntity : class, IDataEntity
    {
        void Export(TDataEntity dataEntity);
    }
}