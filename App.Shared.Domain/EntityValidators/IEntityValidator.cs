using System.Collections.Generic;
using App.Core.Entities;

namespace App.Shared.Domain.EntityValidators
{
    public interface IEntityValidator<in TEntity>
        where TEntity : class, IEntity
    {
        IEnumerable<string> Validate(TEntity entity);
    }
}