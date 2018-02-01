using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.BaseGameEditor.Domain.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories
{
    public class F1ChiefDesignerRepository : RepositoryBase<F1ChiefDesignerEntity>, IF1ChiefDesignerRepository
    {
        public F1ChiefDesignerRepository(List<F1ChiefDesignerEntity> list) : base(list)
        {
        }
    }
}