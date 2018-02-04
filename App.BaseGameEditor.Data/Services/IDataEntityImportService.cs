using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Services
{
    public interface IDataEntityImportService<out TDataEntity>
        where TDataEntity : class, IDataEntity
    {
        TDataEntity Import(int id);
    }
}