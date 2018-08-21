using App.Core.Entities;

namespace App.Shared.Data.Services
{
    public interface IDataEntityExportService<in TEntity>
        where TEntity : class, IEntity
    {
        void Export(TEntity dataEntity);
    }
}