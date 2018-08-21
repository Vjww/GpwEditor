using App.Core.Entities;

namespace App.Shared.Data.Services
{
    public interface IRepositoryImportService<TEntity>
        where TEntity : class, IEntity
    {
        void Import(int itemCount);
    }
}