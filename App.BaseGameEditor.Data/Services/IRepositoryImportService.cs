using App.Core.Entities;

namespace App.BaseGameEditor.Data.Services
{
    public interface IRepositoryImportService<TEntity>
        where TEntity : class, IEntity
    {
        void Import(int itemCount);
    }
}