using System.Collections.Generic;
using App.Core.Entities;

namespace App.BaseGameEditor.Domain.Services
{
    public interface IEntityValidationService<TEntity>
        where TEntity : class, IEntity
    {
        IEnumerable<string> Validate();
    }
}