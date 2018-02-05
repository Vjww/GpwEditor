using App.Core.Entities;

namespace App.BaseGameEditor.Data.Services
{
    public interface IRepositoryExportService<TEntity>
        where TEntity : class, IEntity
    {
        void Export();
    }
}