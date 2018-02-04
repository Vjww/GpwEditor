using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Services
{
    public interface IRepositoryExportService<TDataEntity>
        where TDataEntity : class, IDataEntity
    {
        void Export();
    }
}