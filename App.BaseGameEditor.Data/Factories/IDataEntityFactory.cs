using App.BaseGameEditor.Data.DataEntities;

namespace App.BaseGameEditor.Data.Factories
{
    public interface IDataEntityFactory<out TDataEntity>
        where TDataEntity : class, IDataEntity
    {
        TDataEntity Create(int id);
    }
}