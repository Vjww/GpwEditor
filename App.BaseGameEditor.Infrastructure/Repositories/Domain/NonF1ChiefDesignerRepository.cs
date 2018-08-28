using System.Collections.Generic;
using App.BaseGameEditor.Domain.Entities;
using App.Shared.Infrastructure.Repositories;

namespace App.BaseGameEditor.Infrastructure.Repositories.Domain
{
    public class NonF1ChiefDesignerRepository : RepositoryBase<NonF1ChiefDesignerEntity>
    {
        public NonF1ChiefDesignerRepository(List<NonF1ChiefDesignerEntity> list) : base(list)
        {
        }
    }
}