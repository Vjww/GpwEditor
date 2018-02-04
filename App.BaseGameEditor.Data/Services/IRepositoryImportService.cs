using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Services
{
    public interface IRepositoryImportService<TDataEntity>
        where TDataEntity : class, IDataEntity
    {
        void Import(int itemCount);
    }
}