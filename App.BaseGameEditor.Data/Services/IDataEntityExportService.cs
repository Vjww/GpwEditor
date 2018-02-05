using App.Core.Entities;

namespace App.BaseGameEditor.Data.Services
{
    public interface IDataEntityExportService<in TEntity>
        where TEntity : class, IEntity
    {
        void Export(TEntity dataEntity);
    }
}