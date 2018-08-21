using App.Core.Entities;

namespace App.Shared.Data.Services
{
    public interface IRepositoryExportService<TEntity>
        where TEntity : class, IEntity
    {
        void Export();
    }
}