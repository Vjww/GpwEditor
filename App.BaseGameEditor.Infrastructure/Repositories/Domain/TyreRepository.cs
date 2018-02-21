using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class TyreRepository : RepositoryBase<TyreEntity>
    {
        public TyreRepository(List<TyreEntity> list) : base(list)
        {
        }
    }
}